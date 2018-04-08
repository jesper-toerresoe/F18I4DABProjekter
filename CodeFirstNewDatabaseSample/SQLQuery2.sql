SELECT Users.Username,Organizations.OrganizationName,Countries.CountryName FROM
	 Users INNER JOIN Organizations ON Users.UsersOrg_OrganizationId = Organizations.OrganizationId 
		   INNER JOIN Countries ON Organizations.OrgsCountryId = Countries.CountryId
GO
SELECT 
    [Extent1].[UsersOrgId] AS [UsersOrgId], 
    [Extent1].[Username] AS [Username], 
    [Extent2].[OrganizationName] AS [OrganizationName], 
    [Extent3].[CountryName] AS [CountryName]
    FROM   [dbo].[Users] AS [Extent1]
    INNER JOIN [dbo].[Organizations] AS [Extent2] ON [Extent1].[UsersOrgId] = [Extent2].[OrganizationId]
    INNER JOIN [dbo].[Countries] AS [Extent3] ON [Extent2].[OrgsCountryId] = [Extent3].[CountryId]