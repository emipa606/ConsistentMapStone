# [Consistent Map Stone (Continued)](https://steamcommunity.com/sharedfiles/filedetails/?id=3248599795)

![Image](https://i.imgur.com/buuPQel.png)

Update of Evelyns mod https://steamcommunity.com/sharedfiles/filedetails/?id=2654086748

![Image](https://i.imgur.com/pufA0kM.png)
	
![Image](https://i.imgur.com/Z4GOv8H.png)

# For Users

This mod is compatible with literally anything, do not concern yourself with what it does, it's a framework type mod. Feel free to read the below if you really must know, though. You don't need this unless a mod you want to use is dependent on it.

### FAQ

Q - Can I add this to an existing save?
A - Absolutely, but understand that if your map was generated without it any mods that use this one will get stone types that are unlikely to line up with the ones on your map. They will, from there on out, be consistent with each other though.

Q - Can I remove this safely without messing up my save?
A - Yep!

### Mods That Use This

Soil Relocation https://steamcommunity.com/sharedfiles/filedetails/?id=3248607572
Consistent Deep Drill Stone https://steamcommunity.com/sharedfiles/filedetails/?id=3248605918

# For Modders

This mod allows other mods to get what type of stone would be at a place if it were exposed stone terrain. Without modifying how stone types are distributed around the map, this isn't possible, believe it or not. Strangely, by default, it uses a random seed each time. This means that after the map is generated there's no way to know what that seed was and thus no way to find out what stone would go where.
  
  For modders, to get the stone type at a particular cell, add the assembly reference to this mod and then do something like the following:
  var sg = Map.GetComponentCMS.MapComponent_StoneGrid();
then you can use the following functions on that:

StoneTypeAt(IntVec3) (gives you the ThingDef for the stone type itself)
StoneTerrainAt(IntVec3) (gives you the TerrainDef for the stone type)
StoneChunkAt(IntVec3) (gives you the ThingDef for the chunk of that stone type)

The latter two call the first one and then conveniently drill down to get the relevant values, so if you need to call more than one thing it's more efficient to call the first one and drill down yourself to not duplicate work.
  
Be sure to add it as a dependency for your mod in the Steam upload so it's easy for users to find and install this dependency!

![Image](https://i.imgur.com/PwoNOj4.png)



-  See if the the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using [HugsLib](https://steamcommunity.com/workshop/filedetails/?id=818773962) or the standalone [Uploader](https://steamcommunity.com/sharedfiles/filedetails/?id=2873415404) and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.
-  Use [RimSort](https://github.com/RimSort/RimSort/releases/latest) to sort your mods

 

[![Image](https://img.shields.io/github/v/release/emipa606/ConsistentMapStone?label=latest%20version&style=plastic&color=9f1111&labelColor=black)](https://steamcommunity.com/sharedfiles/filedetails/changelog/3248599795) | tags:  consistency,  map generation
