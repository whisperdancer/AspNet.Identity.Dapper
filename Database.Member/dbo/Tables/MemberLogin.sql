CREATE TABLE [dbo].[MemberLogin] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [MemberId]      INT            NOT NULL,
    CONSTRAINT [PK_dbo.MemberLogin] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [MemberId] ASC),
    CONSTRAINT [FK_dbo.MemberLogin_dbo.Member_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Member] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_MemberId]
    ON [dbo].[MemberLogin]([MemberId] ASC);

