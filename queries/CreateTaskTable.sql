CREATE TABLE Task (
Id int PRIMARY KEY IDENTITY (1,1),
TaskDescription nvarchar(50)NOT NULL,
DueDate DateTime,
IsCompleted BIT,
);
