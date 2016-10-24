CREATE TABLE [dbo].[Proposal] (
    [ID]         INT NOT NULL,
    [ServiceID]  INT NOT NULL,
    [ProposalID] INT NOT NULL,
    CONSTRAINT [PK_Proposal] PRIMARY KEY CLUSTERED ([ProposalID] ASC),
    FOREIGN KEY ([ID]) REFERENCES [dbo].[Customer] ([ID]),
    FOREIGN KEY ([ServiceID]) REFERENCES [dbo].[Services] ([ServiceID])
);



