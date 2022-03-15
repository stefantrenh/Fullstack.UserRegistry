if not exists (select * from dbo.[User])
begin
	insert into dbo.[User] (Name, Address)
	values ('Stefan Trenh', 'NexerGatan 1'),
	('Bassem Hussein', 'NexerGatan 2'),
	('Kiomars Miraseedi', 'NexerGatan 3'),
	('Andrea Klintelius', 'NexerGatan 4'),
	('Mohamad Hadi Mortada', 'NexerGatan 5'),
	('Ted Henriksson', 'NexerGatan 6');
end
