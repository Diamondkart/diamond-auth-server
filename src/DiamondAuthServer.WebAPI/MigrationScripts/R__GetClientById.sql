-- Description: Retrieves client details by ID
-- Parameters: @clientId - ID of the client
-- Author: Prakash Besra
USE [AuthDB]
GO

CREATE OR ALTER PROCEDURE [auth].[SP_GetClient](@clientId NVARCHAR(255))
AS
BEGIN
	SELECT	c.[Name], c.ClientId, 
			c.ClientSecret, c.ClientType, 
			c.[Enabled],c.RequireClientSecret,
			c.AlwaysIncludeUserClaimsInIdToken,
			gt.[Name] AS GrantType, s.[Name] as Scope
	FROM	auth.Client c
	JOIN	auth.ClientGrantTypes cgt 
	ON		c.ID=cgt.ClientId
	JOIN	auth.GrantTypes gt 
	ON		cgt.GrantType=gt.ID
	LEFT	JOIN	auth.ClientScopes cs 
	ON		c.ID=cs.ClientId
	LEFT	JOIN	auth.Scopes s 
	ON		cs.Scope=s.ID
	WHERE	c.ClientId=@clientId
END

GO

