use master;
go

DROP database [Enterprise];
go


CREATE DATABASE [Enterprise];
GO

USE [Enterprise];
GO

Create schema a01;
GO

Drop table [a01].[article];
Drop table [a01].[author];


create table [a01].[author]
(
	authorID int Primary Key Identity(1,1)
	,first_name nvarchar(256) NOT NULL
	,last_name nvarchar(256) NOT NULL
	,[profile] nvarchar(256) NOT NULL
	,email nvarchar(256) NOT NULL  UNIQUE
	,[password] nvarchar(256) NOT NULL
)

create table [a01].[article]
(
	articleID int Primary Key Identity(1,1)
	,article_name nvarchar(256) NOT NULL
	,article_sub_heading nvarchar(256)
	,isfeatured BIT
	,isBreaking BIT
	,category nvarchar(256) NOT NULL
	,content nvarchar(256) NOT NULL
	,authorID int REFERENCES [a01].[Author](AuthorID)
	,imageUrl nvarchar(MAX)
)

Insert into [a01].[author]
VALUES('Christian', 'Bonnici', 'Christian Bonnici 22 Years old', 'christianbonnici@gmail.com','1234567')
,('Journalist','First', 'First Journalist Manually Inserted' , 'MyJournalist@gmail.com', '1234567');


/*Sports Section */
Insert into [a01].[article] (article_name,article_sub_heading,category,content,isfeatured,isBreaking,authorID,imageUrl)
VALUES ('Clamoroso Messi!','Messi Requests Transfer','sports','Messi wants to leave Barcelona to join Aguero at Man. City',1,1,1, 'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Messi.jpg')
,('Milan che fai?!','Crotone winning side','sports','Milan lose 0-2 to Crotone in their homeground',0,0,2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Milan.jpg')
,('C.Ronaldo new deal','Contract Extension','sports','C.Ronaldo is now the highest paid player in Europe',0,0,1,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Ronaldo.jpg')
,('Champions League 2018/2019','Group Stages Draw','sports','The Draw will start next Monday, where both Milan giants have finally qualified, they are both 3rd seed',1,1,1,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//CL.jpg')
,('Zlatan Ibrahimovic','New Club','sports','After his career threatining injury at Manchester United, Zlatan have decided to return to his homegrown club Malmo before deciding to hang his boots',1,1,1,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Zlatan.jpg')


/*national Section */
Insert into [a01].[article] (article_name,article_sub_heading,category,content,authorID,imageUrl)
VALUES ('Malta','Tourists increase','national','Malta had 10% more tourists than the previous year',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Tourist.jpg')
,('National Team','New Callups','national','Beerman is set to make his debut for Malta next friendly against Estonia',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Beerman.jpg')
,('Holiday','New Holiday Announced','national','Another holiday is to be set in August',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Help.jpg')
,('Eurovision','Should we quit?','national','Malta is not what it used to be, should we stop participating in the eurovision?',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Eurovision.jpg')
,('Race Track','Wish granted','national','After many years asking for a race track, it has finally been built and ready to use! ',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//RaceTrack.jpg')

/*Overseas Section */
Insert into [a01].[article] (article_name,article_sub_heading,category,content,authorID,imageUrl)
VALUES ('France','New President','overseas','New President has been announced for France. Future looks bright!',1,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//France.jpg')
,('Italy','Trending Artist','overseas','A new Artist had his music trending and is becoming popular around the world in a matter of days',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Italy.jpg')
,('UK','Brexit','overseas','UK are officially out of the EU',1,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//UK.jpg')
,('Belgium','Simply the best','overseas','Belgium wins the best country of the year',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Belgium.png')
,('Brazil','Investments Required','overseas','After the expenses done for the World Cup, Brazil need investments to survive its financial crisis',1,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Brazil.jpg')
	
/*Opinion Section */
Insert into [a01].[article] (article_name,article_sub_heading,category,content,authorID,imageUrl)
VALUES ('Inter','Next coach?','opinion','Who should coach Inter for next season?',1,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Inter.jpg')
,('Diego Simeone','On the move ?','opinion','Should Diego Simeone join Italian giants Inter or France giants PSG for the following season?',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Simeone.jpg')
,('Belotti','Leave Torino now ?','opinion','Should Belotti join Milan this year or wait for the World Cup to be played first?',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Belotti.jpg')
,('Updates','Is this good enough?','opinion','Does this website need improvements or is it good as it is?',1,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Help.jpg')
,('Other Life','Life on other planets','opinion','Do you think there is life on other planets? Reply to us with your thoughts.',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Help.jpg')

/*Travel Section */
Insert into [a01].[article] (article_name,article_sub_heading,category,content,authorID,imageUrl)
VALUES ('Santorini','#YouShouldBeHere','travel','What are you waiting for? Catch the next flight to Santorini, you will not regret it!',1,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Santorini.jpg')
,('Dream Trip','TravelWithUs!','travel','Join us in our next trip around Europe for only 3333 Euros!',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Help.jpg')
,('Malta','Summer + Malta = Perfection','travel','Need a break from your everyday life? Come to Malta right now! Our beaches will not disappoint!',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Tourist.jpg')
,('LowBudget','Still possible.','travel','Come help us settling in France, and we will pay you the trip!',1,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//France.jpg')
,('StudentLife','Mega Gathering !','travel','Join other Students from other countries on a surprise destination, everything is arranged for only 400 euro',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Tourist.jpg')


/*Odd Section */
Insert into [a01].[article] (article_name,article_sub_heading,category,content,authorID,imageUrl)
VALUES ('Help','Maids needed!!','odd','Need a maid for next Friday to help out!',1,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Help.jpg')
,('MaltaPark','Clearance sale','odd','Come to Fgura primary school to check out, money will be given to charity!',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Help.jpg')
,('Drone','How to fly a drone?','odd','Say no more, in 1 hour I can teach you how to fly your drone , contant me on Drone@FlyDrones.com!',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Drone.jpg')
,('Students','Cry out for help','odd','Students need help from officials to manage their life, attending school, working and preparing for exams is too much for some',1,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Help.jpg')
,('Crisis','Workers needed','odd','Various positions are open, come look us up and if you are qualified, you are guaranteed a job!',2,'https://imagestorageenterprise.blob.core.windows.net/christianbonici//Help.jpg')

Select *
from [a01].[Author];

Select *
from [a01].[article];

Select *
from [a01].[article] art
where art.isfeatured = '1';

Select *
from [a01].[article] art
where art.articleID = '1';
