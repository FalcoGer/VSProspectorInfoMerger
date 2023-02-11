# VSProspectorInfoMerger
Merge information from the Prospector Info mod for vintage story with other people to share the information.

Get the mod here.  
https://mods.vintagestory.at/show/mod/1235

This application requires .Net Desktop Runtime.  
https://dotnet.microsoft.com/en-us/download/dotnet/6.0

# Usage
1. Select your file in the top textbox. The file is typically at `%appdata%/VintageStoryData/ModData/<serverID>/vsprospectorinfo.data.json.
2. Select the file you want to merge into your file. Get your friend to send it to you in some way.
3. Click the Merge button.

A backup will be created.

If the file you want to merge already contains data for a given area, then that entry is ignored.

If the file you want to merge contains data for an area that conflicts with your own data, you will get a warning. If you ignore this warning, your own data will remain and more entries may be merged. If you cancel, no data is written at all.
