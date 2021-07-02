$tasks = @(
'dotnet run -p ./NewTask/NewTask.csproj "A - First message."',
'dotnet run -p ./NewTask/NewTask.csproj "A - Second message.."',
'dotnet run -p ./NewTask/NewTask.csproj "A - Third message..."',
'dotnet run -p ./NewTask/NewTask.csproj "A - Fourth message...."',
'dotnet run -p ./NewTask/NewTask.csproj "A - Fifth message....."'
)

For($i=0;$i-lt $tasks.Length;$i++) {
	Invoke-Expression $tasks[$i]
}