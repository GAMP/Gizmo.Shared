# Code Style Configuration

To have a consistent code style configuration for all solutions using `.editorconfig`, `Directory.Build.props`, and the `dotnet format` CLI command on a repository root level.

## Use the `.editorconfig`

The `.editorconfig` file defines coding conventions such as indentation, spacing, and naming rules. To apply it:

1. Place the `.editorconfig` file in the root directory of your repository.
2. The settings will automatically apply to all files in the repository.
3. To override the settings for a specific project, place an `.editorconfig` file in the project's directory.
4. To configure additional rules, refer to the [EditorConfig documentation](https://editorconfig.org/).

## Use the `Directory.Build.props`

The `Directory.Build.props` file enforces additional code analysis and style rules during the build process. To use it:

1. Place the `Directory.Build.props` file in the root directory of your repository.
2. It will automatically apply to all projects in the repository.
3. To use Warnings as Errors, set the `TreatWarningsAsErrors` property to `true`.
4. To configure additional rules, refer to the [MSBuild documentation](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild).

## Run `dotnet build` command

1. You can run the `dotnet build` command for any projects or solutions and the code style rules will be enforced.
    ```bash
    dotnet build
    ```
2. <span style="color:yellow;font-weight:bold">ATTENTION:</span> Sometimes, the `dotnet build` command may not enforce all code style rules due to caching. To avoid this, run `dotnet clean` before `dotnet build`.
    ```bash
    dotnet clean
    dotnet build
    ```

## Using the `dotnet format` CLI Command

The `dotnet format` command ensures that all files adhere to the defined code style. To use it:

1. Run the following command in the root directory of your repository to apply the possible changes for all files:
    ```bash
    dotnet format
    ```
2. To preview the changes without applying them, use the `--verify-no-changes` option:
    ```bash
    dotnet format --verify-no-changes
    ```
3. To create a report for the required changes, use the `--report <REPORT_PATH>` option:
    ```bash
    dotnet format --report <REPORT_PATH>
    ```
4. <span style="color:yellow;font-weight:bold">ATTENTION:</span> The `dotnet format` command may apply changes more than once.
5. To use additional options, learn more from the [dotnet format documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-format).

## Summary

By combining `.editorconfig`, `Directory.Build.props`, and the `dotnet format` CLI command, you can ensure that all solutions in your repository follow an identical code style. This improves code readability, maintainability, and consistency across the team.
