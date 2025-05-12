using System.ComponentModel.DataAnnotations;

namespace Gizmo.Client
{
    public enum ApplicationSortingOption
    {
        [Localized("GIZ_APP_SORTING_OPTION_POPULARITY")]
        [Name("Popularity", "APPLICATION_SORTING_OPTION_POPULARITY")]
        Popularity = 0,

        [Localized("GIZ_APP_SORTING_OPTION_ADD_DATE")]
        [Name("Add Date", "APPLICATION_SORTING_OPTION_ADD_DATE")]
        AddDate = 1,

        [Localized("GIZ_APP_SORTING_OPTION_TITLE")]
        [Name("Title", "APPLICATION_SORTING_OPTION_TITLE")]
        Title = 2,

        [Localized("GIZ_APP_SORTING_OPTION_USE")]
        [Name("Use", "APPLICATION_SORTING_OPTION_USE")]
        Use = 3,

        [Localized("GIZ_APP_SORTING_OPTION_RATING")]
        [Name("Rating", "APPLICATION_SORTING_OPTION_RATING")]
        Rating = 4,

        [Localized("GIZ_APP_SORTING_OPTION_RELEASE_DATE")]
        [Name("Release Date", "APPLICATION_SORTING_OPTION_RELEASE_DATE")]
        ReleaseDate = 5,
    }
}
