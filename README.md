# LD46
 LD46 - Keep it Alive

 ## LD46 - Post Compo-changes
 - Issue: In the WebGL build, the method changing scenes was causing overlapping scenes, preventing the game from continuing. 
 - Tried adding an emergency restart [was not implemented.]
 - Moved initial scene loading to Start - game objects were instantiated properly in the webgl build. Issue not present in the editor and win. 
 - Duplicate victory could happen - reset variables to avoid this. Still present in some instances. 
 - 
 