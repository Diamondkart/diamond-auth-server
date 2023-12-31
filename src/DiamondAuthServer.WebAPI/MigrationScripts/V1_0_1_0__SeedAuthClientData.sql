USE [AuthDB]
GO

INSERT INTO auth.GrantTypes(ID, [Name]) 
values
('8030bfe5-11e6-4456-b528-04b05c318f1d', 'password'),
('caf12047-f19e-4889-b3af-3c67ee707a80', 'client_credentials'),
('7c293d79-2d50-4da5-b71d-f4ce15900676','authorization_code'),
('c58d5cab-e9fb-4272-97a7-775c88ec3de6', 'implicit'),
('49ea0664-7180-44cf-9852-29fee5216bea', 'hybrid'),
('dbff9486-5d01-4dba-845e-6f770fa08baf', 'urn:ietf:params:oauth:grant-type:device_code');


GO

INSERT INTO auth.Scopes(ID, [Name]) 
values
('8030bfe5-11e6-4456-b528-04b05c318f1d', 'openid'),
('caf12047-f19e-4889-b3af-3c67ee707a80', 'profile'),
('7c293d79-2d50-4da5-b71d-f4ce15900676', 'email'),
('c58d5cab-e9fb-4272-97a7-775c88ec3de6', 'address'),
('49ea0664-7180-44cf-9852-29fee5216bea', 'phone'),
('dbff9486-5d01-4dba-845e-6f770fa08baf', 'offline_access'),
('100c75df-332a-4a2c-9399-12a880031a57','provisionz');

GO

INSERT INTO auth.Client(ID, [Name], ClientId, ClientSecret, ClientType, [Enabled], RequireClientSecret, AlwaysIncludeUserClaimsInIdToken) 
values
('9c6db90a-8925-486b-bf99-c6ede057ad38', 'Auth', 'auth-ropc-9c6db90a-8925-486b-bf99-c6ede057ad38', 'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=', 'Confidential',1, 1, 1),
('AD3B392C-F5A7-EE11-8EB8-70CF49E6D35F', 'Authz', 'InternalClientz', 'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=', 'Confidential',1, 1, 0);

GO

INSERT INTO auth.ClientGrantTypes(ClientID, GrantType) 
values
('9c6db90a-8925-486b-bf99-c6ede057ad38', '8030bfe5-11e6-4456-b528-04b05c318f1d'),
('AD3B392C-F5A7-EE11-8EB8-70CF49E6D35F', 'caf12047-f19e-4889-b3af-3c67ee707a80');

GO

INSERT INTO auth.ClientScopes(ClientID, Scope) 
values
('9c6db90a-8925-486b-bf99-c6ede057ad38', '8030bfe5-11e6-4456-b528-04b05c318f1d'),
('9c6db90a-8925-486b-bf99-c6ede057ad38', 'caf12047-f19e-4889-b3af-3c67ee707a80'),
('AD3B392C-F5A7-EE11-8EB8-70CF49E6D35F', '100c75df-332a-4a2c-9399-12a880031a57');

GO


