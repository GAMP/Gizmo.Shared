using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// User search field priority order.
    /// </summary>
    /// <remarks>
    /// The configured order is held as a single option value, a comma separated list of <see cref="UserSearchFieldType"/>
    /// member names, highest priority first. One value keeps the ordering atomic, the option store is a flat key value
    /// table and offers no constraint that could tie one value per field together, so a single value is the only shape
    /// that cannot be written half way, hold a duplicate rank or lose a field.
    /// <para>
    /// Member names rather than the numeric values because the enum has been renumbered before, composites were inserted
    /// in the middle of it, and stored ordinals would have silently reshuffled every configured order.
    /// </para>
    /// </remarks>
    public static class UserSearchFieldPriority
    {
        /// <summary>
        /// Value separator.
        /// </summary>
        public const char SEPARATOR = ',';

        /// <summary>
        /// Gets the default priority order, the order the fields are declared in.
        /// </summary>
        /// <remarks>
        /// This reproduces the ranking that was hardcoded before the order became configurable, so an installation that
        /// never opens the setting keeps the search results it had.
        /// </remarks>
        public static IReadOnlyList<UserSearchFieldType> Default { get; } = Enum.GetValues<UserSearchFieldType>()
            .OrderBy(fieldType => (int)fieldType)
            .ToArray();

        /// <summary>
        /// Parses a stored priority value into the field order it describes.
        /// </summary>
        /// <param name="value">Stored option value, null or empty for the default order.</param>
        /// <returns>Every <see cref="UserSearchFieldType"/> member exactly once, highest priority first.</returns>
        /// <remarks>
        /// Deliberately tolerant, this runs on the search path and a value no reader can make sense of must degrade to the
        /// default order rather than break user search. Unknown names are ignored so a value written by a newer version
        /// stays readable, duplicates keep their first and highest position, and members the value does not mention are
        /// appended in declaration order so a field added in a later version simply starts out last.
        /// </remarks>
        public static IReadOnlyList<UserSearchFieldType> Parse(string? value)
        {
            var ordered = new List<UserSearchFieldType>(Default.Count);
            var seen = new HashSet<UserSearchFieldType>();

            if (!string.IsNullOrWhiteSpace(value))
            {
                foreach (var token in value.Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                {
                    if (!Enum.TryParse<UserSearchFieldType>(token, true, out var fieldType) || !Enum.IsDefined(fieldType))
                        continue;

                    if (seen.Add(fieldType))
                        ordered.Add(fieldType);
                }
            }

            foreach (var fieldType in Default)
            {
                if (seen.Add(fieldType))
                    ordered.Add(fieldType);
            }

            return ordered;
        }

        /// <summary>
        /// Resolves a stored priority value into a lookup of field priorities.
        /// </summary>
        /// <param name="value">Stored option value, null or empty for the default order.</param>
        /// <returns>Priority of each field, indexed by <see cref="UserSearchFieldType"/> value, lower ranks higher.</returns>
        /// <remarks>
        /// An array indexed by the enum value lets the search projection look a field up without a dictionary lookup or a
        /// closure the expression tree cannot hold.
        /// </remarks>
        public static int[] Resolve(string? value)
        {
            var ordered = Parse(value);
            var priorities = new int[Default.Max(fieldType => (int)fieldType) + 1];

            for (var index = 0; index < ordered.Count; index++)
            {
                priorities[(int)ordered[index]] = index;
            }

            return priorities;
        }

        /// <summary>
        /// Formats a field order into a value for the option store.
        /// </summary>
        /// <param name="fieldTypes">Field order, highest priority first.</param>
        /// <returns>Comma separated member names.</returns>
        public static string Format(IEnumerable<UserSearchFieldType> fieldTypes)
        {
            ArgumentNullException.ThrowIfNull(fieldTypes);

            return string.Join(SEPARATOR, fieldTypes);
        }
    }

    /// <summary>
    /// Validates that an option value describes a complete user search field priority order.
    /// </summary>
    /// <remarks>
    /// Writes are held to a full permutation even though <see cref="UserSearchFieldPriority.Parse"/> accepts less, an
    /// incomplete value stored here would be a silently reordered search rather than a visible error. String option values
    /// are stored verbatim, no type conversion validates them, so this attribute is the only thing standing between the
    /// settings page and an unusable value.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class UserSearchFieldPriorityValidationAttribute : ValidationAttribute
    {
        /// <inheritdoc/>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //an unset value is the default order, the setting has never been written
            if (value is null)
                return ValidationResult.Success;

            if (value is not string stringValue)
                return new ValidationResult("User search field priority must be a string.", GetMemberNames(validationContext));

            if (string.IsNullOrWhiteSpace(stringValue))
                return ValidationResult.Success;

            var seen = new HashSet<UserSearchFieldType>();

            foreach (var token in stringValue.Split(UserSearchFieldPriority.SEPARATOR, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                if (!Enum.TryParse<UserSearchFieldType>(token, true, out var fieldType) || !Enum.IsDefined(fieldType))
                    return new ValidationResult($"Unknown user search field: ({token}).", GetMemberNames(validationContext));

                if (!seen.Add(fieldType))
                    return new ValidationResult($"Duplicate user search field: ({token}).", GetMemberNames(validationContext));
            }

            if (seen.Count != UserSearchFieldPriority.Default.Count)
                return new ValidationResult("Every user search field must appear exactly once in the priority order.", GetMemberNames(validationContext));

            return ValidationResult.Success;
        }

        private static string[] GetMemberNames(ValidationContext validationContext) =>
            validationContext.MemberName is { } memberName ? [memberName] : [];
    }
}
