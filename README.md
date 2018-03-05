# ALBY


Getting started guide
1. Download the release from the release tab - [Found here](https://github.com/ALBY-Project/ALBY/releases)
2. Extract it and do not remove any files. The current release requires meta.snk, System.Management.Automation.dll. 
This will hopefully not be necessarry in future releases.
3. Start it by running Alby.exe


## Example - MSBuild.exe bypass using Empire Agent

1. Start Alby.exe
2. Choose 1 for the MSBuild menu like this:
![Alt text](images/Example1.jpg?raw=true "MSBuild option")
3.  Choose option 2 for an Empire agent based bypass
![Alt text](images/Example2.jpg?raw=true "MSBuild - Empire Agent option")
4. Copy your Empire payload from your Empire server that you can generate by using: 
usestager multi/launcher http
generate
(Note: Only copy the base64 encoded command)
5. Enter the output filename you want and press enter. Use enter without typing anything to use the default.
6. Enter your wanted output path and press enter. 
7. Now you get the needed command highlighted in green. Copy this command so that you don't need to type it.
8. Copy the output bypass file to the host you want to test and run the command from step 7. 


![Alt text](images/Example1-Animation.gif?raw=true "MSBuild - Empire Agent animation")