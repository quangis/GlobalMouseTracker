# GlobalMouseTracker

Can track on global level mouse movements, left click, right click, and wheel spin.

How to use:

1: With the Open button, select a blank textfile to which the results will be written (Note that content of the file will be deleted).

2.1: File writing frequency - For performance reasons, tracking results are cached into memory before being written to the textfile. For example, given value 500, every 500 tracking results are stored in memory first and then stored in bulk into the textfile.

2.2: Mouse move capture frequency - Mouse movement is captured after every N milliseconds.

2.3: Save changes to the frequency parameters with the Save button. 

3: Indicate which mouse events to track.

4: Start tracking by pressing the button at the bottom.

5: Press "Stop tracking" once done with tracking. All cached results will be saved to the file.
 
