CREATE TABLE [dbo].[MemberRole] (
    [MemberId] INT NOT NULL,
    [RoleId]   INT NOT NULL,
    CONSTRAINT [PK_dbo.MemberRoles] PRIMARY KEY CLUSTERED ([MemberId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.MemberRoles_dbo.Member_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Member] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.MemberRoles_dbo.Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_MemberId]
    ON [dbo].[MemberRole]([MemberId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[MemberRole]([RoleId] ASC);

