# GitHub Copilot Instructions for Consistent Map Stone (Continued)

## Mod Overview and Purpose

**Consistent Map Stone (Continued)** is a framework mod originally created by Evelyn, designed to ensure consistent stone type mapping across RimWorld map tiles. The mod does not alter the natural distribution of stone types around the map but instead allows other mods to access information on what stone type would have been generated at specific locations. This functionality is vital for mods that require the determination of stone types on a pre-generated map, ensuring a unified and predictable interaction with stone types.

## Key Features and Systems

- **Consistent Stone Type Mapping**: Provides functionality to predict the stone type at any given location on the map, maintaining consistency across mods.
- **In-game Integration**: Offers methods for obtaining stone type, terrain, and chunks at specific map cells using the `MapComponent_StoneGrid` component.
- **Compatibility**: Fully compatible with all mods and can be added to or removed from existing saves without issues.
- **Dependencies**: Requires Harmony (brrainz.harmony) for patching functionalities.

## Coding Patterns and Conventions

- **Namespace and Class Structures**: 
  - The main logic resides in `MapComponent_StoneGrid`, which includes methods like `StoneTypeAt`, `StoneTerrainAt`, and `StoneChunkAt`.
  - The primary entry point for mods utilizing this functionality is typically set up through `Map.GetComponentCMS.MapComponent_StoneGrid()` to retrieve the stone-related methods.

- **Method Usage**:
  - `StoneTypeAt(IntVec3)`: Fetches the `ThingDef` for the stone type at a given cell.
  - `StoneTerrainAt(IntVec3)`: Retrieves the `TerrainDef` for the terrain of that stone type.
  - `StoneChunkAt(IntVec3)`: Gets the `ThingDef` for the chunk of that stone type.
  - It is advisable to use `StoneTypeAt` directly and subsequently derive the terrain and chunk information to optimize performance.

## XML Integration

- **Mod Metadata**: Define the mod's metadata, dependencies, and version information in `About.xml` and `Manifest.xml`. Both XML files should indicate the dependency on brrainz.harmony.
- **Mod Dependencies in XML**: Include Harmony integration in the XML files to ensure the mod operates correctly with the planned patching and stone type retrieval workflows.

## Harmony Patching

- **Harmony Library**: Utilized to modify game methods without altering original code. This ensures that the mod remains compatible even across game updates and integrates seamlessly with the game's core mechanics.
- **Implementation**: Defined in `RockNoises_Init.cs` with a `Prefix` method to customize map generation aspects.

## Suggestions for Copilot

- **Method Suggestions**: Copilot should assist in generating boilerplate code for accessing `MapComponent_StoneGrid` and leveraging its methods like `StoneTypeAt`, `StoneTerrainAt`, and `StoneChunkAt`.
- **Patch Patterns**: Guide through creating Harmony patches, particularly in extending or altering map generation processes.
- **Optimization Tips**: Recommend patterns that call primary functions like `StoneTypeAt` once and derive subsequent data, preventing redundant method calls and improving mod performance.
- **Error Handling Advices**: Provide suggestions for logging and debugging, including instructive comments for users to assist mod problems through logs or the designated Discord channel.

By following these guidelines and utilizing Copilot effectively, you can seamlessly integrate and extend the functionalities provided by Consistent Map Stone (Continued) in your mods.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

