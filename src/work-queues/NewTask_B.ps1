$tasks = @(
'dotnet run -p ./NewTask/NewTask.csproj "B - First message."',
'dotnet run -p ./NewTask/NewTask.csproj "B - Second message.."',
'dotnet run -p ./NewTask/NewTask.csproj "B - Third message..."',
'dotnet run -p ./NewTask/NewTask.csproj "B - Fourth message...."',
'dotnet run -p ./NewTask/NewTask.csproj "B - Fifth message....."'
)

For($i=0;$i-lt $tasks.Length;$i++) {
	Invoke-Expression $tasks[$i]
}