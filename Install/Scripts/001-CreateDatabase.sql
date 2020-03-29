USE [master]
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'BusquedaVehiculos')
DROP DATABASE [BusquedaVehiculos]
GO

CREATE DATABASE [BusquedaVehiculos]
GO
