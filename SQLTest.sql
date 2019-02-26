use ITrocDB

select*from AspNetUsers
select*from AspNetRoles
select*from AspNetUserRoles
select*from __MigrationHistory

delete __MigrationHistory where MigrationId='201902221430559_testmigration'
select*from ads
select*from categories
select*from codepostal
select*from images


delete Ads where ads.id in
(select ads.id from ads 
left join Images on Ads.Id=Images.AdId
where images.adid is null)

select *from ads 
left join Images on Ads.Id=Images.AdId
where  Ads.Id=11


sp_help ads
truncate table ads


Alter Table ads Drop Constraint DF__Ads__AdImgFileNa__35BCFE0A
Alter Table ads Alter Column AdImgFileName nvarchar(max) not null
Alter Table ads Add Constraint DF__Ads__AdImgFileNa__35BCFE0A  Default '' for AdImgFileName


select Cast(GETDATE() as datetime)
select CONVERT(DATETIME2(0), getdate())

select getDate()
select*from __MigrationHistory

update ads set CodePostalId=26771

select*from codepostal where cp=77000
insert into Categories values('JEUX UNLOCK!');

declare @AdTitle varchar(50)='Echange du Jeux Unlock - Mystery Adventures';
declare @AdDescription varchar(50)='Jeux en parfait etat pour la description vous pouve';
declare @DT DATETIME=(select CONVERT(DATETIME2(0), getdate()));
declare @UserGuid varchar(50)=(select id from AspNetUsers where username='user1@itroc.com');
insert into Ads values(@AdTitle,@AdDescription,@DT,0,1,@UserGuid,26771,'15 rue du Pin','firstimg.jpg');

select*from Codepostals where id=33746

update AspNetUsers set Adresse='56 rue Lavigne',CodePostal='75002'
where username=(select UserName from AspNetUsers where UserName='admin@itroc.com')




SELECT 
    [Project1].[Id] AS [Id], 
    [Project1].[AdTitle] AS [AdTitle], 
    [Project1].[AdDescription] AS [AdDescription], 
    [Project1].[AdCeate] AS [AdCeate], 
    [Project1].[Poubelle] AS [Poubelle], 
    [Project1].[AdAdresse] AS [AdAdresse], 
    [Project1].[CategoryId] AS [CategoryId], 
    [Project1].[CodePostalId] AS [CodePostalId], 
    [Project1].[UserId] AS [UserId], 
    [Project1].[Id1] AS [Id1], 
    [Project1].[CatName] AS [CatName], 
    [Project1].[Id2] AS [Id2], 
    [Project1].[Adresse] AS [Adresse], 
    [Project1].[CodePostal] AS [CodePostal], 
    [Project1].[Ville] AS [Ville], 
    [Project1].[Email] AS [Email], 
    [Project1].[EmailConfirmed] AS [EmailConfirmed], 
    [Project1].[PasswordHash] AS [PasswordHash], 
    [Project1].[SecurityStamp] AS [SecurityStamp], 
    [Project1].[PhoneNumber] AS [PhoneNumber], 
    [Project1].[PhoneNumberConfirmed] AS [PhoneNumberConfirmed], 
    [Project1].[TwoFactorEnabled] AS [TwoFactorEnabled], 
    [Project1].[LockoutEndDateUtc] AS [LockoutEndDateUtc], 
    [Project1].[LockoutEnabled] AS [LockoutEnabled], 
    [Project1].[AccessFailedCount] AS [AccessFailedCount], 
    [Project1].[UserName] AS [UserName], 
    [Project1].[Id3] AS [Id3], 
    [Project1].[Cp] AS [Cp], 
    [Project1].[Ville1] AS [Ville1], 
    [Project1].[C1] AS [C1], 
    [Project1].[Id4] AS [Id4], 
    [Project1].[AdId] AS [AdId], 
    [Project1].[FileBase64] AS [FileBase64], 
    [Project1].[Poubelle1] AS [Poubelle1]
    FROM ( SELECT 
        [Extent1].[Id] AS [Id], 
        [Extent1].[AdTitle] AS [AdTitle], 
        [Extent1].[AdDescription] AS [AdDescription], 
        [Extent1].[AdCeate] AS [AdCeate], 
        [Extent1].[Poubelle] AS [Poubelle], 
        [Extent1].[AdAdresse] AS [AdAdresse], 
        [Extent1].[CategoryId] AS [CategoryId], 
        [Extent1].[CodePostalId] AS [CodePostalId], 
        [Extent1].[UserId] AS [UserId], 
        [Extent2].[Id] AS [Id1], 
        [Extent2].[CatName] AS [CatName], 
        [Extent3].[Id] AS [Id2], 
        [Extent3].[Adresse] AS [Adresse], 
        [Extent3].[CodePostal] AS [CodePostal], 
        [Extent3].[Ville] AS [Ville], 
        [Extent3].[Email] AS [Email], 
        [Extent3].[EmailConfirmed] AS [EmailConfirmed], 
        [Extent3].[PasswordHash] AS [PasswordHash], 
        [Extent3].[SecurityStamp] AS [SecurityStamp], 
        [Extent3].[PhoneNumber] AS [PhoneNumber], 
        [Extent3].[PhoneNumberConfirmed] AS [PhoneNumberConfirmed], 
        [Extent3].[TwoFactorEnabled] AS [TwoFactorEnabled], 
        [Extent3].[LockoutEndDateUtc] AS [LockoutEndDateUtc], 
        [Extent3].[LockoutEnabled] AS [LockoutEnabled], 
        [Extent3].[AccessFailedCount] AS [AccessFailedCount], 
        [Extent3].[UserName] AS [UserName], 
        [Extent4].[Id] AS [Id3], 
        [Extent4].[Cp] AS [Cp], 
        [Extent4].[Ville] AS [Ville1], 
        [Extent5].[Id] AS [Id4], 
        [Extent5].[AdId] AS [AdId], 
        [Extent5].[FileBase64] AS [FileBase64], 
        [Extent5].[Poubelle] AS [Poubelle1], 
        CASE WHEN ([Extent5].[Id] IS NULL) THEN CAST(NULL AS int) ELSE 1 END AS [C1]
        FROM     [dbo].[Ads] AS [Extent1]
        INNER JOIN [dbo].[Categories] AS [Extent2] ON [Extent1].[CategoryId] = [Extent2].[Id]
        LEFT OUTER JOIN [dbo].[AspNetUsers] AS [Extent3] ON [Extent1].[UserId] = [Extent3].[Id]
        INNER JOIN [dbo].[Codepostals] AS [Extent4] ON [Extent1].[CodePostalId] = [Extent4].[Id]
        LEFT OUTER JOIN [dbo].[Images] AS [Extent5] ON [Extent1].[Id] = [Extent5].[AdId]
        WHERE 0 = [Extent1].[Poubelle]
    )  AS [Project1]
    ORDER BY [Project1].[Id] ASC, [Project1].[Id1] ASC, [Project1].[Id2] ASC, [Project1].[Id3] ASC, [Project1].[C1] ASC