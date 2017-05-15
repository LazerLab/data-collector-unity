# Copy the player scripts into the WebGL Export template for the Unity project
cp JS/vs-unity-globals.js Assets/WebGLTemplates/VolunteerScienceTemplate/JS
cp JS/vs-unity-player.js Assets/WebGLTemplates/VolunteerScienceTemplate/JS

# Remove the dashes from the filenames for the host (auto-stripped by Volunteer Science)
cp JS/vs-unity-globals.js Host/vsunityglobals.js
cp JS/vs-unity-host.js Host/vsunityhost.js
