CREATE TABLE [dbo].[MemberClaim] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [MemberId]   INT            NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.MemberClaim] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.MemberClaim_dbo.Member_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Member] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_MemberId]
    ON [dbo].[MemberClaim]([MemberId] ASC);

