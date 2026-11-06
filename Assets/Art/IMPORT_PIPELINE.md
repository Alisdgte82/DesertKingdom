
# Sultans Sands — Architecture Asset Pipeline

## Project
- Game: Sultans' Sands (رمال السلاطين)
- Repository: DesertKingdom
- Unity: 2022.3.62f2
- Platform: Android
- Visual direction: realistic Arabian desert kingdom, angled isometric camera.

## 1. Architecture asset source

First candidate:
- Pack: Desert Mosque and Madrasa Courtyard
- Source: https://3dassets.dev/packs/desert-mosque-and-madrasa-courtyard
- Manifest: https://3dassets.dev/api/v1/packs/desert-mosque-and-madrasa-courtyard
- Demo: https://3dassets.dev/demos/desert-mosque-and-madrasa-courtyard

The pack is a candidate source for modular architecture pieces:
- Pointed arch bays and corners
- Courtyard walls and gates
- Ribbed domes
- Carved plaster details
- Decorative screens
- Courtyard paving and fountains

IMPORTANT:
This is not a complete royal palace or finished game environment.
Verify the current CC0 1.0 licence and save its licence information before commercial use.

## 2. Import folder structure

Place source models here:

Assets/Art/Imported/DesertCourtyard/

Generated review prefabs go here:

Assets/Art/Prefabs/DesertCourtyard/

Keep original downloaded files unchanged.

## 3. Importer

Unity package:
KhronosGroup UnityGLTF

Repository:
https://github.com/KhronosGroup/UnityGLTF

Version:
release/2.14.1

Package identifier:
org.khronos.unitygltf

The project uses Unity 2022.3.62f2.
Do not change the Unity version just to install an asset importer.

## 4. Import procedure

1. Download the complete architecture pack from its official source.
2. Verify its licence and preserve the licence document.
3. Extract GLB files into the import folder.
4. Allow Unity to import the models.
5. Check the Console for errors.
6. Run:

Sultans Sands > Art Pipeline > Validate Imported Architecture

7. Run:

Sultans Sands > Art Pipeline > Create Staging Prefabs

8. Inspect the generated prefabs before using them in the kingdom scene.

## 5. Quality checks

Every imported model must be checked for:

- Correct scale and orientation.
- Missing materials and textures.
- Mesh density and triangle count.
- Draw calls and material count.
- Texture resolution and Android compression.
- Pivot and hierarchy.
- Colliders where needed.
- LOD groups.
- Lighting and shadow cost.
- Performance on the target Android phone.

## 6. Final environment requirements

The finished kingdom must include:

- A large original Arabian royal palace.
- Connected defensive stone walls.
- Detailed towers and gates.
- Arabian houses and strategic buildings.
- Winding desert roads.
- Small green oases and water features.
- Detailed sandstone materials.
- Smooth isometric camera movement and zoom.
- Mobile-optimized LOD and rendering.

No mountains or oversized trees.

No primitive cubes as final architecture.

## 7. Licensing and originality

- Do not use assets with unclear licences.
- Do not use non-commercial assets in a commercial game.
- Do not copy proprietary models or textures from another game.
- Keep source URLs and licence records for every external asset.
- Treat all imported prefabs as staging assets until reviewed.

## 8. Important limitation

This pipeline does not automatically build a complete game environment.
Unity Editor import and visual inspection require a compatible Unity Editor environment. Unity Editor is not a native Android application.
