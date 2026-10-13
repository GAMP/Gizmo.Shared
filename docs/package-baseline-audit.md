# Gizmo.Shared public NuGet publishing — baseline audit and provenance gate (GHI-23)

| Field | Value |
| --- | --- |
| Task | GHI-23 — "Audit and preserve public package baseline" |
| Primary issue | [GAMP/Gizmo.Shared#23](https://github.com/GAMP/Gizmo.Shared/issues/23) |
| Planning contract | [GAMP/Gizmo.Infra#20](https://github.com/GAMP/Gizmo.Infra/issues/20) |
| Deliverable type | Evidence-only audit and provenance gate — **not** a package migration |
| Snapshot date | 2026-10-13 (all remote/feed/Actions observations) |
| Scope of this PR | Documentation only. No production code, workflow, metadata, tag, protected/source branch, package, or release change. |
| Selected baseline | `Gizmo.Shared` **1.0.16** (proven `RepositoryCommit`, matching tag as a content mapping only, net10.0 consumer exercised) |
| Overall result | Observable evidence is recorded below. Task acceptance remains **blocked** by operator-only evidence: protected-branch enforcement, tag immutability, and the `NUGET_USER` / NuGet.org Trusted Publishing policy were not directly inspected. |

This document is self-contained: it records the measured 2026-10-13 snapshot and
the exact commands to reproduce it.

---

## 1. Purpose and scope (read first)

- This repository is an **existing pilot already publishing** to NuGet.org. It is
  the dependency gate for downstream reusable libraries, not a migration target
  (see Shared#23 "Purpose" and Infra#20 "Lane 1 — baseline").
- The required outcome is an **audit and provenance gate**: prove the workflow,
  protected branches, source SHA, package identity, feed/tag provenance, and a
  usable baseline, or state precisely what is not proven.
- This PR is **one narrow documentation PR in `Gizmo.Shared` only**. No existing
  tag is moved, no previously published version is republished or overwritten, and
  **no new release or publication is triggered**.
- Downstream stable publication stays **blocked** until Shared#23 confirms a
  usable, provenance-verified stable baseline and the operator-only settings are
  exported (see §11, §13).

---

## 2. Source refs (exact refs and SHAs)

Remote `origin` = `https://github.com/GAMP/Gizmo.Shared.git`. All values observed
2026-10-13 via `git ls-remote origin` and fresh objects.

| Ref | Full SHA | Notes |
| --- | --- | --- |
| `refs/heads/pre-release` (development) | `091b578922abbe7287e80b62819bb4c81dacc28b` | branch tip; `protected=true` (§11) |
| `refs/heads/release` (production) | `0eaa125bfd05ce33247e29143b3f01aa72c95f05` | branch tip; `protected=true`; equals `v1.0.16` |
| `refs/heads/version-3` | `ecee0ef0822b95af1eb55cef6f2de98be8d5a1dd` | history source; `protected=false` |
| `refs/heads/dev` | `baaf209fceb89c19d7bb3f45c012623cabe46928` | `protected=false`; 2 divergent commits (§10) |
| `refs/heads/main` | `dd7077166341a7df99884d6753405f6708ed8a09` | `protected=false`; local checkout HEAD |
| `refs/tags/Gizmo.Shared/v1.0.13` | `51dbf1f379f8ca42320e0edaca9eaf84bb4b82e1` | lightweight tag |
| `refs/tags/Gizmo.Shared/v1.0.14` | `740b6ca29870ee49615d961e7529c7655d8172fb` | lightweight tag |
| `refs/tags/Gizmo.Shared/v1.0.15` | `6e01bb3da20828ff02a4112466b8c6ba1850d67e` | lightweight tag |
| `refs/tags/Gizmo.Shared/v1.0.16` | `0eaa125bfd05ce33247e29143b3f01aa72c95f05` | lightweight tag; == `release` tip |

The complete `Gizmo.Shared/v*` tag set is exactly `v1.0.13`–`v1.0.16` (observed via
`git ls-remote --tags`); there are **no** tags for any other published version.

Key commit:

- `release` tip `0eaa125` — *"Merge pull request #22 from GAMP/pre-release"*,
  Fri Oct 9 14:45:43 2026 +0200. Parents: `6e01bb3` (`v1.0.15` tip) and
  `091b578` (`pre-release` tip).

---

## 3. Workflow, Gizmo.Infra pin, and project metadata

Observed 2026-10-13.

| Item | Value |
| --- | --- |
| Gizmo.Infra pin (referenced from caller `package.yml`) | `ee6fbd96adbcfba997755376a2c227f536c210d7` |
| Gizmo.Infra `main` HEAD at observation | same SHA — **no ref drift** |
| `docs/caller.md` blob | `a39cad05272145588ebbf16b68bcac06e3346493` |
| `docs/provider.md` blob | `ed5a61d14b82374c9d698e7fc135ff328871c226` |
| `.github/templates/package.yml` blob | `57eeb3370cb1477e011739339c101ac18e324100` |
| Infra reusable `.github/workflows/package.yml` blob | `56046a96938f4c88d867f62560ad5d7ea572796e` |
| Gizmo.Infra actions present | `internal`, `nuget`, `preflight`, `tag` |

Caller invariants observed:

- `pre-release` and `release` each contain **exactly one** workflow file:
  `.github/workflows/package.yml`.
- That file is **byte-identical** on both protected branches (blob
  `ce5837aec3307bb1ff22b1f49bd108038562d6e6`), and pins every Gizmo.Infra
  reference to the single SHA `ee6fbd96adbcfba997755376a2c227f536c210d7`.
- `main` and `version-3` contain **no** `.github/workflows/package.yml`.
- The caller `nuget` job publishes only when `needs.plan.outputs.publisher ==
  'nuget'`, passes `user: ${{ vars.NUGET_USER }}`, and requests
  `id-token: write` (OIDC). The `tag` job runs only for the production line and
  only after a publisher succeeded.

### 3.1 Project metadata (MSBuild evaluation of the release source)

`Gizmo.Shared.csproj` at `0eaa125` (and identical at `091b578`):

| Property | Value |
| --- | --- |
| `IsPackable` | `true` |
| `PackageId` | `Gizmo.Shared` (not set explicitly → defaults to assembly name; matches nuspec id) |
| `Version` / csproj declared | `1.0` |
| `TargetFramework` (`TargetFrameworks` empty) | `net10.0` |
| `AssemblyName` / `RootNamespace` | `Gizmo.Shared` |
| `Nullable` | `enable` |
| `GeneratePackageOnBuild` | `False` |
| `IncludeSymbols` / `SymbolPackageFormat` | `true` / `snupkg` |
| `RepositoryUrl` / `RepositoryType` | `https://github.com/GAMP/Gizmo.Shared` / `git` |
| `PackageLicenseExpression` | `MIT` |

Exactly one project exists in the checkout, and it is packable (`csproj count: 1`,
`sln count: 0`). `<Version>1.0</Version>` is the canonical `X.Y`; the pipeline
assigns the concrete `X.Y.patch` / `X.Y.patch-dev.N` (Infra#20 runtime contract).

> Note (observed drift on an unrelated ref, not fixed here): the `version-3` tip
> `ecee0ef` carries a pre-GHI-19 `<Version>1.0.14.0</Version>`; the promoted line
> (`pre-release` → `release`) is `1.0`.

---

## 4. Observed NuGet.org feed (complete history)

Source: `https://api.nuget.org/v3-flatcontainer/gizmo.shared/index.json`
(fetched 2026-10-13). That **flat-container index** enumerates the whole feed in a
single response with **no version pagination** — **22 versions, 16 stable + 6
prerelease** — so this enumeration is the completeness basis. The search API result
`totalHits = 1` confirms only that **one package matches** (`Gizmo.Shared`); it
counts package results, **not** versions, and is **not** evidence of historical
version completeness.

**Stable:** `1.0.0, 1.0.1, 1.0.3, 1.0.4, 1.0.5, 1.0.6, 1.0.7, 1.0.8, 1.0.9, 1.0.10,
1.0.11, 1.0.12, 1.0.13, 1.0.14, 1.0.15, 1.0.16`

**Prerelease:** `1.0.14-dev.3, 1.0.14-dev.6, 1.0.15-dev.12, 1.0.16-dev.18,
1.0.16-dev.21, 1.0.16-dev.31`

- There is **no `1.0.2`** and **no `2.x` line**; only the `1.0` line exists.
- Highest stable = `1.0.16`.

**Feed versions are not the same thing as tags** (see §5). Older feed versions
(`1.0.0`–`1.0.11`) are published, but their nuspec `RepositoryCommit` provenance
was **not inspected** and is therefore **not verified**; the full tag set (§2)
contains **no** tags for them, and no matching tags were invented.

---

## 5. Published version → tag → source SHA provenance mapping

`RepositoryCommit` values were read from each package's nuspec at
`https://api.nuget.org/v3-flatcontainer/gizmo.shared/<version>/gizmo.shared.nuspec`.
Every nuspec carries `repository type="git"
url="https://github.com/GAMP/Gizmo.Shared"` and a single `net10.0` dependency
group.

| Published version | nuspec `RepositoryCommit` | Matching tag | Tag/commit relation |
| --- | --- | --- | --- |
| `1.0.16` | `0eaa125bfd05ce33247e29143b3f01aa72c95f05` | `Gizmo.Shared/v1.0.16` | commit == tag == `release` tip |
| `1.0.15` | `6e01bb3da20828ff02a4112466b8c6ba1850d67e` | `Gizmo.Shared/v1.0.15` | commit == tag |
| `1.0.14` | `740b6ca29870ee49615d961e7529c7655d8172fb` | `Gizmo.Shared/v1.0.14` | commit == tag |
| `1.0.13` | `51dbf1f379f8ca42320e0edaca9eaf84bb4b82e1` | `Gizmo.Shared/v1.0.13` | commit == tag |
| `1.0.12` | `e89d00791dbfb4af2ddaa6e14a2e1b9896911d08` | **absent** | commit exists, no `v1.0.12` tag |
| `1.0.0`–`1.0.11` | not inspected | **absent** | full tag set has no tags for these; provenance not verified |

**Interpretation guard.** This table proves a **content mapping** between the
published nuspec `RepositoryCommit`, the git tag, and the branch commit for
`1.0.13`–`1.0.16`. It is **not** proof that the tag is server-side immutable, and
it is **not** proof of publication by itself — see §9 and §11.

---

## 6. Selected baseline and consumer proof

**Selected baseline: `Gizmo.Shared` 1.0.16.**

- Provenance: published `1.0.16` `RepositoryCommit` == tag `Gizmo.Shared/v1.0.16`
  == `release` tip `0eaa125b…` (§5).
- Consumer: a minimal net10.0 console app restored/built/ran against the published
  `1.0.16` from the feed and produced `Gizmo.LineType.Product = 0` (§7) — the
  package is net10.0-only and the net10.0 consumer resolved and executed it.
- The published package's own nuspec (resolved inside a fresh packages folder)
  reports `<version>1.0.16</version>` and
  `<repository … commit="0eaa125b…" />` with a single `lib/net10.0` asset group.

This baseline is suitable for downstream net10.0 consumers **subject to** the
operator-only gate in §11: the audit does not certify Trusted Publishing
configuration or tag/branch enforcement.

---

## 7. Fresh consumer reproduction (source, commands, measured result)

### 7.1 Measured command evidence (commands actually run, 2026-10-13)

Recorded in the task-local retained evidence
`.tasks/GHI-23/docs/standalone-verification.md` §8 (not shipped in this PR) against
the published `1.0.16`:

```powershell
dotnet restore Gizmo.Shared.Consumer.csproj        # exit 0 — restored 1.0.16 from the feed
# build (dedicated Dotnet MCP tool, no shell bypass):
#   tools.dotnet.build({ target: ".tasks/GHI-23/consumer/Gizmo.Shared.Consumer.csproj",
#                        configuration: "Release", noRestore: true })
#   runId r9bm4DEsjr_OuOpbxxe8IK1uNnvmqRubmowoYAPC9P0, status succeeded,
#   exitCode 0, errorCount 0, warningCount 0
dotnet run --project Gizmo.Shared.Consumer.csproj -c Release --no-build
```

Measured output (**exit 0**):

```text
Resolved assembly: Gizmo.Shared v1.0.0.0
InformationalVersion: 1.0+0eaa125bfd05ce33247e29143b3f01aa72c95f05
Gizmo.LineType.Product = 0
```

### 7.2 Consumer source (reuses only existing public API)

`Gizmo.Shared.Consumer.csproj`:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <AssemblyName>Gizmo.Shared.Consumer</AssemblyName>
    <RootNamespace>Gizmo.Shared.Consumer</RootNamespace>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Gizmo.Shared" Version="1.0.16" />
  </ItemGroup>
</Project>
```

`Program.cs` (references `Gizmo.LineType`, a public enum in the `Gizmo`
namespace; no API is invented):

```csharp
using System.Reflection;
using Gizmo;

// Proves the Gizmo.Shared 1.0.16 NuGet asset is resolvable and usable from a
// net10.0 consumer: a public enum type is referenced at compile time and the
// resolved assembly identity is read at runtime.
var assembly = typeof(LineType).Assembly;
var name = assembly.GetName();
var informational = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

Console.WriteLine($"Resolved assembly: {name.Name} v{name.Version}");
Console.WriteLine($"InformationalVersion: {informational}");
Console.WriteLine($"Gizmo.LineType.Product = {(int)LineType.Product}");
```

`nuget.config` — clear to nuget.org only, fresh global packages folder. The
measured run used an absolute fresh folder (`.tasks/GHI-23/packages`); this
**optional reproduction** config uses the concrete relative path `.packages`,
created fresh inside the consumer directory (this value was never
`.<fresh-packages-dir>`):

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <config>
    <add key="globalPackagesFolder" value=".packages" />
  </config>
  <packageSources>
    <clear />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
</configuration>
```

### 7.3 Optional reproduction (separate from the measured run above)

Write the three files above into a fresh `<consumer>` directory, then (optionally
add `--no-http-cache` to force a network download instead of the HTTP cache; not
used in the measured run):

```powershell
dotnet restore <consumer>\Gizmo.Shared.Consumer.csproj --no-http-cache
dotnet build   <consumer>\Gizmo.Shared.Consumer.csproj -c Release --no-restore
dotnet run --project <consumer>\Gizmo.Shared.Consumer.csproj -c Release --no-build
```

---

## 8. Standalone restore / build / pack — authoritative repeat verification

The directly captured repeat in the task-local retained evidence
`.tasks/GHI-23/docs/standalone-repeat-verification.md` (not shipped in this PR) is
**authoritative** and **supersedes** the earlier ambiguous pack transcription in
`.tasks/GHI-23/docs/standalone-verification.md` §7 (that transcription's working
directory was never captured and is not reconstructed from output). A fresh standalone detached
checkout (own `.git`, no sibling source repos, no copied `bin`/`obj`) was created
at the exact release SHA; the parent clone was untouched.

### 8.1 Environment

- Default SDK (no `global.json`): `11.0.100-rc.1.26425.128` (a **preview** SDK).
- Installed SDKs: `6.0.428`, `9.0.318`, `10.0.112`, `11.0.100-rc.1.26425.128`.
- Installed runtimes include `Microsoft.NETCore.App 10.0.12` (used for the
  net10.0 consumer).
- NuGet sources: `nuget.org` only.
- No `global.json` / `Directory.Build.props` / `Directory.Build.targets` /
  `Directory.Packages.props` / `NuGet.config` exists in any ancestor of the
  checkout (the repo's `CodeStyle/Directory.Build.props` is a sibling, not
  auto-imported).

### 8.2 Exact commands (CWD = repository root `D:\repos\gizmo\Gizmo.Shared`)

```powershell
# fresh standalone checkout at the exact release SHA (explicit SHA, not a local ref)
New-Item -ItemType Directory -Force .tasks/GHI-23/docs/verification-repeat/checkout
git -C .tasks/GHI-23/docs/verification-repeat/checkout init
git -C .tasks/GHI-23/docs/verification-repeat/checkout remote add origin https://github.com/GAMP/Gizmo.Shared.git
git -C .tasks/GHI-23/docs/verification-repeat/checkout fetch --depth 1 origin 0eaa125bfd05ce33247e29143b3f01aa72c95f05
git -C .tasks/GHI-23/docs/verification-repeat/checkout checkout --detach FETCH_HEAD
#   HEAD is now at 0eaa125 "Merge pull request #22 from GAMP/pre-release"   exit 0

# restore (explicit workspace-relative project path, no bare filename)
dotnet restore .tasks/GHI-23/docs/verification-repeat/checkout/Gizmo.Shared.csproj
#   Restored …checkout\Gizmo.Shared.csproj (in 797 ms).   EXIT=0
#   (dotnet restore has no -c/--configuration option)

# build (dedicated Dotnet MCP tool; no raw `dotnet build` fallback):
#   tools.dotnet.build({ target: ".tasks/GHI-23/docs/verification-repeat/checkout/Gizmo.Shared.csproj",
#                        configuration: "Release", noRestore: true })

# pack (explicit project path AND explicit -o path, CWD = repository root)
dotnet pack .tasks/GHI-23/docs/verification-repeat/checkout/Gizmo.Shared.csproj -c Release --no-build -o .tasks/GHI-23/docs/verification-repeat/artifacts
#   Successfully created …\Gizmo.Shared.1.0.0.nupkg / .snupkg   EXIT=0
```

### 8.3 Measured results

| Step | Evidence |
| --- | --- |
| Restore | `Restored …checkout\Gizmo.Shared.csproj (in 797 ms)`, exit 0 |
| Build (MCP) | runId `zCAlzp2Fh24nVcdwqKrdWk5zTOR-ycaFlMsHyEu1uLo`, status `succeeded`, `exitCode 0`, `durationMs 37885`, `errorCount 0`, `warningCount 180` |
| Pack | exit 0 → `Gizmo.Shared.1.0.0.nupkg` (**371,758 bytes**) + `Gizmo.Shared.1.0.0.snupkg` (**54,943 bytes**) |

The 180 raw warnings deduplicate to 39 distinct messages across 10 codes:
CS8765 (×13), CS8618 (×9), CS8604 (×5), CS8603 (×4), CS0612 (×3), CS0672 (×1),
CS8612 (×1), CS8625 (×1), CS8622 (×1), CS8600 (×1). These are SDK-default
analyzer/nullability warnings; `TreatWarningsAsErrors` is not set, so warnings are
not a build gate.

The pack targeted the **isolated checkout** project (net10.0), not the stale
repository-root project (`Gizmo.Shared.csproj`, `netstandard2.0`,
`Version=1.0.5.0`); the generated nuspec reports `<version>1.0.0</version>` and
`<repository … commit="0eaa125b…" />`, matching the checkout SHA.

> **Local `1.0.0` must never be published.** `<Version>1.0</Version>` yields a
> local `1.0.0`; the published `1.0.16` is assigned by the pipeline independently
> of the csproj. No `push` was invoked; the artifact is local-only.

Byte identity between the local rebuild/pack and the published package is **not**
established (recorded as an observation only; no cause is claimed — see §13).

---

## 9. Actions run evidence

`package.yml` runs, from GitHub Actions metadata (public). `run_number` correlates
with the `-dev.N` suffix on the development line.

| Run | Ref / SHA | Event | Pin | Conclusion | Publish step |
| --- | --- | --- | --- | --- | --- |
| [31](https://github.com/GAMP/Gizmo.Shared/actions/runs/37931269104) | `pre-release` `091b578` | push | `ee6fbd96` | success | `Publish public package` success (12:38:05–12:38:09Z); `internal`/`tag` skipped (dev line) |
| [33](https://github.com/GAMP/Gizmo.Shared/actions/runs/37932173356) | `release` `0eaa125` | push | `ee6fbd96` | success | `Publish public package` success (12:46:28–12:46:35Z) |
| [9](https://github.com/GAMP/Gizmo.Shared/actions/runs/37016290905) | `release` `740b6ca` (`v1.0.14`) | push | `9b703b0` | **failure** (final attempt 4) | attempt 1 publish success (13:56:10–13:56:18Z) + `tag` success; attempts 2–4 publish failed |
| [14](https://github.com/GAMP/Gizmo.Shared/actions/runs/37353286857) | `release` `6e01bb3` (`v1.0.15`) | push | `0c708be` | success (attempt 2) | attempt 1 success (18:05:48–18:05:55Z); attempt 2 success |

**Interpretation guards (important):**

- **What each signal proves:** the **feed entry proves the package is
  published/available**; the run's `Publish public package` job success is
  **direct metadata** that the step concluded successfully; the feed `published`
  timestamp is **near-in-time correlation only**; the literal `dotnet nuget push` vs
  already-exists/skip log message is **inaccessible** (admin-only).
- A green `Publish public package` step **alone is not proof of a live upload**:
  the pipeline produces *idempotent-skip* successes on a re-run of an
  already-published version (run 14, attempt 2 — `1.0.15` already existed and
  NuGet rejects overwrites).
- Run 33 correlation: the `1.0.16` registration leaf
  (`https://api.nuget.org/v3/registration5-semver1/gizmo.shared/1.0.16.json` →
  `published = 2026-10-09T12:46:35.557Z`, `listed = true`) is **0.557 s after** run
  33's `Publish public package` step `completed_at` (12:46:35Z) — a **near-in-time
  correlation only**, not a claim that it falls inside any exact step window. With
  `run_attempt = 1`, head `0eaa125` == the `1.0.16` nuspec `RepositoryCommit`, and no
  earlier stable `1.0.16`, the timing is consistent with run 33. The literal `dotnet
  nuget push` vs already-exists/skip log message is **inaccessible** (admin-only,
  §11), so **no publisher and no OIDC/Trusted Publishing configuration is inferred**;
  the policy binding remains an operator check (§11).
- **Historic run 9 (`1.0.14`):** attempt 1's publish **and** `tag` steps succeeded
  (`1.0.14` leaf `published = 2026-10-02T13:56:17.783Z` correlates near-in-time with
  attempt 1's publish step); the top-level `failure` reflects the failed **re-runs**
  (attempts 2–4). The step outcomes are **known**; only the exact upload-vs-skip log
  message is unverified (admin-only, as for every other version).
- The `nuget` action gate (Gizmo.Infra `.github/actions/nuget@ee6fbd96…`) requires
  `event == push`, `github.ref_protected == true`, and a `refs/heads/*` ref;
  `NUGET_USER` must match `^[A-Za-z0-9][A-Za-z0-9._-]{0,127}$`; publication uses
  OIDC (`id-token: write`) to obtain a short-lived key.

---

## 10. Branch promotion / ancestry and the promotion procedure

Ancestry computed with fresh objects (`git rev-list --left-right --count A...B`
and `git merge-base --is-ancestor`):

| Comparison (A ... B) | A-only | B-only | A is ancestor of B? |
| --- | --- | --- | --- |
| `version-3 ... pre-release` | 0 | 25 | yes (exit 0) |
| `version-3 ... release` | 0 | 32 | yes |
| `pre-release ... release` | 0 | 7 | yes |
| `main ... version-3` | 0 | 484 | yes |
| `version-3 ... dev` | 229 | 2 | no (divergent) |
| `pre-release ... dev` | 254 | 2 | no (divergent) |

- `main` contributes **0** commits absent from the promoted line
  (`main ... version-3` = `0 484`, `main ... pre-release` = `0 509`,
  `main ... dev` = `0 257`).
- `version-3` contributes **0** commits absent from `pre-release` and `release`;
  the promoted line contains the whole `version-3` history.
- `release` (`0eaa125`) has parents `6e01bb3` (prior release tip, `v1.0.15`) and
  `091b578` (`pre-release` tip) — i.e. production promoted a validated
  development commit, as the Infra#20 contract requires ("demonstrate that
  invariant with a release procedure and evidence").

### 10.1 Retained divergent `dev` history

`git cherry -v <pre-release> <dev>` shows `dev`'s only 2 unique commits are **not
patch-equivalent** to anything in `pre-release`:

1. `89e5fc9` "restore options." renames option members
   (`IntegrationId`→`LocationId`, drops `BranchId`/`HostId`/…). The source paths
   were relocated to `Gizmo.Client/Options/`, and the rename target `LocationId`
   is **absent** at `0eaa125` (`git grep LocationId 0eaa125 -- '*.cs'` → exit 1).
   This is a **divergence**: mere relocation plus the absence of `LocationId`
   does **not** prove these changes are semantically superseded.
2. `baaf209` "package updates." bumps `Microsoft.Extensions.Logging.Abstractions`
   `6.0.0 → 9.0.6`; the promoted line is **observed** at `10.0.6` (strictly newer).

This retained `dev` history is **outside the selected already-promoted baseline**
(`pre-release` → `release`). **No merge, cherry-pick, or discard was performed**;
semantic super-session of the divergent commits is **not** claimed, and
reconciliation is **not** asserted as required (source reconciliation is out of
scope for this audit). Recorded as an observation only.

### 10.2 Promotion procedure (documented, not executed)

The intended promotion path, documented for the record — **not executed by this
PR** (no promotion, release, or publication is performed):

1. open a **reviewed PR into `pre-release`** (development) with the change;
2. record and validate the **exact `pre-release` head SHA** from that PR;
3. open a **PR promoting that validated development state into `release`**
   (production);
4. after merge, verify **ancestry / tree equality / Actions run** for the promoted
   state.

`protected=true` alone is **not** ancestry evidence. The existing `release` parents
(`6e01bb3`, `091b578`) and dev run 31 satisfy the **observed promotion instance
only**; the procedure above is not asserted as historically enforced — that is an
operator check (§11).

---

## 11. Enforcement and protection — direct evidence vs operator attestation

### 11.1 Direct evidence available

- Connector `list_branches` reports `pre-release protected=true`,
  `release protected=true`, and `version-3` / `dev` / `main protected=false`.
  **`protected=true` is not PR-only proof**: it does not expose required reviews,
  required status checks, push restrictions, or bypass actors.
- The GitHub connector exposes **no** surface for branch protection, rulesets,
  Actions variables/permissions, workflow runs/logs, or environments. Anonymous
  public REST probes (2026-10-13) confirm the gap:

  | Endpoint | Result |
  | --- | --- |
  | `/repos/GAMP/Gizmo.Shared/branches/pre-release/protection` | `401` |
  | `/repos/GAMP/Gizmo.Shared/branches/release/protection` | `401` |
  | `/repos/GAMP/Gizmo.Shared/rulesets` | `200 []` (unauthenticated observation; not evidence of absence) |
  | `/repos/GAMP/Gizmo.Shared/actions/variables` | `401` |
  | `/repos/GAMP/Gizmo.Shared/actions/permissions` | `401` |
  | `/repos/GAMP/Gizmo.Shared/environments` | `200 {"total_count":0,"environments":[]}` |
  | `/repos/GAMP/Gizmo.Shared/actions/runs/37932173356/logs` | `403` Must have admin rights |
  | `/repos/GAMP/Gizmo.Shared/immutable-releases` | `401` |

- **Tag content mapping is not immutability proof.** §5 proves content equality
  only (nuspec `RepositoryCommit` == tag object == branch commit for
  `1.0.13`–`1.0.16`); a lightweight tag can still be moved or deleted by a
  privileged actor unless tag protection / release immutability is enabled and
  verified.

### 11.2 Operator attestation (separate from direct evidence)

On 2026-10-13, in response to the unavailable PR-only branch rules,
tag-protection rules, `NUGET_USER`, and NuGet Trusted Publishing policy, the
operator stated:

> "All of them is in place. I confirm"

Recorded as an **operator attestation only**:

- The exact enforcement/reviews/admin/bypass/force-push/delete settings and the
  NuGet owner/repo/workflow/ref/environment policy settings were **not inspected
  or exported**.
- This attestation **does not satisfy the direct-evidence obligation** and **does
  not unblock** the downstream publication gate on its own.

### 11.3 Operator evidence still required (authenticated admin session; no secret values)

1. Branch protections for `pre-release` and `release` (or the governing ruleset):
   required PR before merge, required approving reviews count,
   dismiss-stale-reviews, require-conversation-resolution, required status checks
   and bindings, restricted push actors, `allow_force_pushes=false`,
   `allow_deletions=false`.
2. Exact **bypass scope**: branch-protection "who can bypass", and for rulesets
   the bypass actors list + bypass modes (always / pull_request) with roles,
   teams, apps, deploy keys. Confirm `rulesets=[]` vs branch-protection.
3. Tag immutability: whether `Gizmo.Shared/v*` tags are protected (tag protection
   rule or a ruleset targeting tags), or repository "immutable releases" is
   enabled.
4. NuGet.org Trusted Publishing policy: owner/account (`NUGET_USER` name), policy
   name, package pattern, and bindings — repository owner/name, workflow file path
   (`.github/workflows/package.yml`), and exact ref/environment binding.
5. Actions variable `NUGET_USER`: configured scope (repo/org/environment), and
   whether any environment protection gates publishing (anonymous view shows 0
   environments).
6. Export/verify the run 33 `nuget`-job log (admin-only) to confirm the real
   `dotnet nuget push` vs skip message.

---

## 12. Separate-repository follow-up (Gizmo.Infra, not edited here)

Two independent Gizmo.Infra documentation observations, both **not** modified by
this PR (GHI-23 requires no needless workflow rewrite and no cross-repo change):

- `docs/caller.md` carries a **historical adoption example** that still shows the
  `1.0.13` → `1.0.14` sequence. That example is **stale** relative to the current
  published line; it is a documentation example only, **not** template functional
  drift.
- The Gizmo.Infra template vs the caller `package.yml` differs by **placeholder
  instantiation plus one reworded header comment (line 2)** — cosmetic only, **no
  change needed**.

Correcting either the stale example or the cosmetic comment is a
**separate-repository follow-up** in Gizmo.Infra and is deliberately out of scope
here.

---

## 13. Unresolved items and risks

1. **Operator-only settings not directly verified** (§11): PR-only enforcement,
   bypass/admin scope, force-push/delete blocking, tag immutability, `NUGET_USER`
   scope, and the Trusted Publishing policy binding. Generic attestation is
   recorded but does not close this.
2. **Historic `1.0.14` run 9:** attempt 1's publish **and** `tag` steps succeeded
   and the feed timestamp correlates near-in-time with attempt 1's publish step; the
   top-level `failure` reflects failed re-runs (attempts 2–4). Step outcomes are
   **known**; only the literal upload-vs-skip log message is unverified (admin-only,
   `403`).
3. **Assembly byte identity unestablished** (§8.3): local rebuild/pack and the
   published package hashes differ; no cause is claimed and no functional
   equivalence is inferred.
4. **Prerelease feed timestamps not retrieved.** `1.0.14-dev.*`, `1.0.15-dev.12`,
   and `1.0.16-dev.*` `published` timestamps returned `404` from the observed
   `registration5-semver1` endpoint. This is a **limitation of that endpoint as
   queried**, not a claim that prerelease registration is impossible via every
   API (a semver2 endpoint was **not** queried); prerelease runs are evidenced by
   run conclusions only.
5. **Older feed versions (`1.0.0`–`1.0.11`) provenance not inspected**; their tags
   are **absent** (full tag set = `v1.0.13`–`v1.0.16`), and **`1.0.12` is
   untagged**; no historic tags may be fabricated for them.

---

## 14. Acceptance criteria mapping (Shared#23)

| AC | Requirement (abridged) | Status in this PR |
| --- | --- | --- |
| AC1 | Checked-in evidence/reproducible commands for workflow, protected branches, source SHA, public package identity | **Blocked / partial** — workflow, SHAs, package identity, and reproducible commands are recorded (§2–§4, §15). Protected-branch *enforcement* is `protected=true` + operator attestation only (§11); blocked on direct operator evidence. |
| AC2 | Stable line and tag/provenance history cross-checked against the real feed; selected baseline + consumer compatibility proven | **Mapping established; enforced immutability unverified** — complete feed list (§4), provenance mapping `1.0.13`–`1.0.16` + untagged `1.0.12` (§5), baseline `1.0.16` and net10 consumer (§6–§7). Enforced tag immutability and older-version provenance remain unverified (§11, §13). |
| AC3 | Standalone restore/build/pack and consumer restore recorded with exact commands and results | **Measured** — isolated-checkout restore/build (MCP runId `zCAlz…`)/pack and consumer restore/build (MCP runId `r9bm…`)/run, with commands and outcomes (§7–§8). |
| AC4 | No existing tag moved, package overwritten, needless workflow rewrite, branch reconciliation, or release triggered | **Met** — docs-only; no production code, workflow, tag, package, or release mutation, and no protected/source branch modification (the audit branch `GHI-23-package-baseline-audit` is an ordinary working branch, not a protected/source branch) (§1). |
| AC5 | One narrow GHI-23 PR with required evidence, AC mapping, risks; reviewer findings addressed | **Pending** — this single docs-only PR plus the PR description; reviewer findings remain blocking and are not self-resolved. |

Downstream publication gate: **still blocked** until operator evidence in §11.3 is
exported and reviewers accept AC1/AC2.

---

## 15. Reproducible commands (read-only / local-only)

All commands below are read-only or local; **none publish, push, tag, or mutate
remote state.**

```powershell
# 2. Refs and the complete tag set
git ls-remote origin refs/heads/pre-release refs/heads/release refs/heads/version-3 refs/heads/dev refs/heads/main
git ls-remote --tags origin "refs/tags/Gizmo.Shared/v*"      # only v1.0.13..v1.0.16 exist

# 4/5. Feed history and provenance (public, no credentials)
invoke-restmethod https://api.nuget.org/v3-flatcontainer/gizmo.shared/index.json
invoke-restmethod https://api.nuget.org/v3-flatcontainer/gizmo.shared/1.0.16/gizmo.shared.nuspec
invoke-restmethod https://api.nuget.org/v3/registration5-semver1/gizmo.shared/1.0.16.json

# 10. Ancestry
git fetch --no-tags origin version-3 pre-release release dev main
git merge-base --is-ancestor ecee0ef0822b95af1eb55cef6f2de98be8d5a1dd 091b578922abbe7287e80b62819bb4c81dacc28b   # exit 0
git rev-list --left-right --count main...version-3                                                                   # 0  484
git rev-list --left-right --count 091b578922abbe7287e80b62819bb4c81dacc28b...0eaa125bfd05ce33247e29143b3f01aa72c95f05  # 0  7

# 9. Actions metadata (public), and the admin-only log probe
invoke-restmethod https://api.github.com/repos/GAMP/Gizmo.Shared/actions/runs/37932173356 | select run_number,event,head_sha,run_attempt,conclusion
invoke-restmethod https://api.github.com/repos/GAMP/Gizmo.Shared/actions/runs/37932173356/logs   # 403 without admin
```

Standalone restore/build/pack exact commands are in §8.2; consumer
restore/build/run commands are in §7.1.

---

## 16. Snapshot identity, links, and revalidation

- **Snapshot date 2026-10-13.** Feeds, remote refs, Actions history, and owner
  metadata are **volatile**; revalidate
  `api.nuget.org/v3-flatcontainer/gizmo.shared/index.json`, `git ls-remote`, and
  the Actions runs before relying on this document later.
- Local working-copy caveat: the parent clone's local `origin/release` is
  `6e01bb3` (`v1.0.15`) and its tag set stops at `v1.0.15`; the remote advanced to
  `0eaa125b…` (`v1.0.16`). Revalidation must fetch the exact remote SHA rather
  than trust the stale local refspec (this is a local-copy condition, not a repo
  defect, and no repository change is made for it here).
- Issues: [Shared#23](https://github.com/GAMP/Gizmo.Shared/issues/23) ·
  [Infra#20](https://github.com/GAMP/Gizmo.Infra/issues/20)
- Source: [release tree `0eaa125`](https://github.com/GAMP/Gizmo.Shared/tree/0eaa125bfd05ce33247e29143b3f01aa72c95f05) ·
  [`package.yml`](https://github.com/GAMP/Gizmo.Shared/blob/0eaa125bfd05ce33247e29143b3f01aa72c95f05/.github/workflows/package.yml) ·
  [Infra tree `ee6fbd96`](https://github.com/GAMP/Gizmo.Infra/tree/ee6fbd96adbcfba997755376a2c227f536c210d7)
- NuGet: [package page](https://www.nuget.org/packages/Gizmo.Shared) ·
  [flat-container index](https://api.nuget.org/v3-flatcontainer/gizmo.shared/index.json) ·
  [1.0.16 registration](https://api.nuget.org/v3/registration5-semver1/gizmo.shared/1.0.16.json)
- Actions: [run 31](https://github.com/GAMP/Gizmo.Shared/actions/runs/37931269104) ·
  [run 33](https://github.com/GAMP/Gizmo.Shared/actions/runs/37932173356) ·
  [run 9](https://github.com/GAMP/Gizmo.Shared/actions/runs/37016290905) ·
  [run 14](https://github.com/GAMP/Gizmo.Shared/actions/runs/37353286857)

This document records what was directly observed; where evidence is missing it is
named as missing rather than inferred. It deliberately does **not** claim tag
immutability, PR-only enforcement, Trusted Publishing configuration, or
publication completeness from indirect signals.
