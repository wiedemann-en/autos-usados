USE [BusquedaVehiculos]
GO

INSERT INTO TB_Provider (CodProvider, DescProvider, UrlBase, UrlCompleta)
VALUES ('ALAMAULA', 'AlaMaula', 'http://www.alamaula.com/', 'http://www.alamaula.com/[FILTRO_TIPO]/[FILTRO_UBICACION]/[FILTRO_MARCA]~[FILTRO_MODELO]~[FILTRO_COMBUSTIBLE]~[FILTRO_COLOR]~[FILTRO_CONDICION]/[PAGINA]/[FILTRO_TIPO][FILTRO_UBICACION][CANTIDAD_FILTROS][FILTRO_MARCA][FILTRO_MODELO][FILTRO_COMBUSTIBLE][FILTRO_COLOR][FILTRO_CONDICION][PAGINA]?[FILTRO_ANIO]&[FILTRO_KILOMETROS]&[FILTRO_PRECIO]&[ORDEN]');
INSERT INTO TB_Provider (CodProvider, DescProvider, UrlBase, UrlCompleta)
VALUES ('AUTOFOCO', 'AutoFoco', 'https://www.autofoco.com/', 'https://www.autofoco.com/[FILTRO_TIPO]/[FILTRO_UBICACION]-/autos/-[FILTRO_SEGMENTO]/[FILTRO_MARCA]/[FILTRO_MODELO]?[FILTRO_TIPO]&[FILTRO_PRECIO]&[FILTRO_ANIO]&[FILTRO_KILOMETROS]&[FILTRO_TRANSMISION]&[FILTRO_TRACCION]&[FILTRO_COMBUSTIBLE]&[FILTRO_DIRECCION]&[FILTRO_COLOR]&[ORDEN]&[PAGINA]');
INSERT INTO TB_Provider (CodProvider, DescProvider, UrlBase, UrlCompleta)
VALUES ('DEAUTOS', 'DeAutos', 'http://listado.deautos.com/', 'http://listado.deautos.com/[FILTRO_TIPO]-[FILTRO_MARCA]-[FILTRO_MODELO]-[FILTRO_UBICACION]/[FILTRO_TIPO][FILTRO_MARCA][FILTRO_MODELO][FILTRO_ANIO][FILTRO_PRECIO][FILTRO_KILOMETROS][FILTRO_SEGMENTO][FILTRO_UBICACION][FILTRO_COMBUSTIBLE][FILTRO_COLOR][ORDEN][PAGINA]');
INSERT INTO TB_Provider (CodProvider, DescProvider, UrlBase, UrlCompleta)
VALUES ('DEMOTORES', 'DeMotores', 'http://autos.demotores.com.ar/', 'http://autos.demotores.com.ar/[FILTRO_TIPO]-[FILTRO_MARCA]-[FILTRO_MODELO]-[FILTRO_SEGMENTO]-[FILTRO_UBICACION]/vtZ1[FILTRO_MARCA][FILTRO_MODELO][FILTRO_UBICACION][FILTRO_COMBUSTIBLE][FILTRO_DIRECCION][FILTRO_SEGMENTO][FILTRO_TIPO][FILTRO_TRANSMISION][FILTRO_PUERTAS][FILTRO_COLOR][FILTRO_ANIO][FILTRO_PRECIO][FILTRO_KILOMETROS][PAGINA][ORDEN]');
INSERT INTO TB_Provider (CodProvider, DescProvider, UrlBase, UrlCompleta)
VALUES ('MERCADOLIBRE', 'MercadoLibre', 'http://autos.mercadolibre.com.ar/', 'http://autos.mercadolibre.com.ar/[FILTRO_MARCA]/[FILTRO_MODELO]/[FILTRO_UBICACION][PAGINA][ORDEN][FILTRO_TIPO][FILTRO_ANIO][FILTRO_PRECIO][FILTRO_COLOR][FILTRO_COMBUSTIBLE][FILTRO_DIRECCION][FILTRO_PUERTAS][FILTRO_TRANSMISION][FILTRO_KILOMETROS]');
INSERT INTO TB_Provider (CodProvider, DescProvider, UrlBase, UrlCompleta)
VALUES ('OLX', 'Olx', 'https://www.olx.com.ar/nf/', 'https://[FILTRO_UBICACION].olx.com.ar/nf/[FILTRO_TIPO][PAGINA]/[FILTRO_MARCA][FILTRO_MODELO][FILTRO_KILOMETROS][FILTRO_ANIO][FILTRO_PRECIO][FILTRO_TRANSMISION][FILTRO_COMBUSTIBLE][ORDEN]');

INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('TIPO', 'Tipo');
INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('MAR', 'Marca');
INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('MOD', 'Modelo');
INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('PROV', 'Provincia');
INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('COL', 'Color');
INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('COMB', 'Combustible');
INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('TRANS', 'Transmision');
INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('DIR', 'Direccion');
INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('SEG', 'Segmento');
INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('TRAC', 'Traccion');
INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('KIL', 'Kilometraje');
INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('PTAS', 'Puertas');
INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('COND', 'Condicion');
INSERT INTO TB_Catalogo (CodCatalogo, DescCatalogo) VALUES ('ORD', 'ORD');

INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_TIPO', 0, 'TIPO');
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_MARCA', 1, 'MAR');
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_MODELO', 1, 'MOD');
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_UBICACION', 1, 'PROV');
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_ANIO', 0, NULL);
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_KILOMETROS', 0, NULL);
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_PRECIO', 0, NULL);
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_DIRECCION', 1, 'DIR');
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_COMBUSTIBLE', 1, 'COMB');
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_TRANSMISION', 1, 'TRANS');
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_SEGMENTO', 1, 'SEG');
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_PUERTAS', 1, 'PTAS');
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_TRACCION', 1, 'TRAC');
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_COLOR', 1, 'COL');
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('FILTRO_CONDICION', 1, 'COND');
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('ORDEN', 1, 'ORD');
INSERT INTO TB_ComponenteUrl (CodComponente, RequiereCatalogo, CodCatalogo) VALUES ('PAGINA', 0, NULL);

INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('ALAMAULA', 'TIPO');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('ALAMAULA', 'MAR');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('ALAMAULA', 'MOD');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('ALAMAULA', 'PROV');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('ALAMAULA', 'COL');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('ALAMAULA', 'COMB');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('ALAMAULA', 'KIL');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('ALAMAULA', 'COND');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('ALAMAULA', 'ORD');

INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('AUTOFOCO', 'TIPO');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('AUTOFOCO', 'MAR');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('AUTOFOCO', 'MOD');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('AUTOFOCO', 'PROV');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('AUTOFOCO', 'COL');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('AUTOFOCO', 'COMB');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('AUTOFOCO', 'TRANS');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('AUTOFOCO', 'DIR');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('AUTOFOCO', 'SEG');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('AUTOFOCO', 'TRAC');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('AUTOFOCO', 'KIL');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('AUTOFOCO', 'ORD');

INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEAUTOS', 'TIPO');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEAUTOS', 'MAR');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEAUTOS', 'MOD');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEAUTOS', 'PROV');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEAUTOS', 'COL');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEAUTOS', 'COMB');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEAUTOS', 'SEG');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEAUTOS', 'KIL');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEAUTOS', 'ORD');

INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEMOTORES', 'TIPO');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEMOTORES', 'MAR');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEMOTORES', 'MOD');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEMOTORES', 'PROV');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEMOTORES', 'COL');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEMOTORES', 'COMB');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEMOTORES', 'TRANS');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEMOTORES', 'DIR');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEMOTORES', 'SEG');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEMOTORES', 'KIL');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEMOTORES', 'PTAS');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('DEMOTORES', 'ORD');

INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('MERCADOLIBRE', 'TIPO');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('MERCADOLIBRE', 'MAR');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('MERCADOLIBRE', 'MOD');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('MERCADOLIBRE', 'PROV');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('MERCADOLIBRE', 'COL');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('MERCADOLIBRE', 'COMB');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('MERCADOLIBRE', 'TRANS');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('MERCADOLIBRE', 'DIR');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('MERCADOLIBRE', 'KIL');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('MERCADOLIBRE', 'PTAS');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('MERCADOLIBRE', 'ORD');

INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('OLX', 'TIPO');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('OLX', 'MAR');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('OLX', 'MOD');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('OLX', 'PROV');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('OLX', 'COMB');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('OLX', 'TRANS');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('OLX', 'KIL');
INSERT INTO TB_ProviderCatalogo (CodProvider, CodCatalogo) VALUES ('OLX', 'ORD');


INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('ALAMAULA', 'FILTRO_TIPO', 's-autos-usados@v1c65');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('ALAMAULA', 'FILTRO_MARCA', '[Value]@ma');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('ALAMAULA', 'FILTRO_MODELO', '[Value]@mo');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('ALAMAULA', 'FILTRO_UBICACION', '[Desc]@l[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('ALAMAULA', 'FILTRO_ANIO', 'cy=[ValueDesde],[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('ALAMAULA', 'FILTRO_KILOMETROS', 'km=[ValueDesde],[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('ALAMAULA', 'FILTRO_PRECIO', 'pr=[ValueDesde],[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('ALAMAULA', 'FILTRO_COMBUSTIBLE', '[Value]@cf');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('ALAMAULA', 'FILTRO_COLOR', '[Value]@co');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('ALAMAULA', 'FILTRO_CONDICION', '[Value]@ro');
--INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('ALAMAULA', 'ORDEN', 'sort=[Value]&order=[ValueTipo]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('ALAMAULA', 'ORDEN', '[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('ALAMAULA', 'PAGINA', 'page-[Value]@p[Value]');

INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'FILTRO_TIPO', '[Value]@type_autos_moderated=moderated');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'FILTRO_MARCA', '[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'FILTRO_MODELO', '[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'FILTRO_UBICACION', '[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'FILTRO_ANIO', 'type_autos_year=[ValueDesde]-[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'FILTRO_KILOMETROS', 'type_autos_mileage=[ValueDesde]-[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'FILTRO_PRECIO', 'type_autos_price=[ValueDesde]-[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'FILTRO_DIRECCION', 'type_autos_steering=[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'FILTRO_COMBUSTIBLE', 'type_autos_fuel=[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'FILTRO_TRANSMISION', 'type_autos_transmission=[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'FILTRO_SEGMENTO', '[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'FILTRO_TRACCION', 'type_autos_drive=[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'FILTRO_COLOR', 'type_autos_color=[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'ORDEN', 'orderBy=[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('AUTOFOCO', 'PAGINA', 'page=[Value]');

INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEAUTOS', 'FILTRO_TIPO', 'autos-usados@VTYY1');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEAUTOS', 'FILTRO_MARCA', '[Desc]@WWMAYY[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEAUTOS', 'FILTRO_MODELO', '[Desc]@WWMOYY[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEAUTOS', 'FILTRO_UBICACION', '[Desc]@WWPVYY[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEAUTOS', 'FILTRO_ANIO', 'WWYEYY[ValueDesde]-[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEAUTOS', 'FILTRO_KILOMETROS', 'WWVKYY[ValueDesde]-[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEAUTOS', 'FILTRO_PRECIO', 'WWPRYY[ValueDesde]-[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEAUTOS', 'FILTRO_COMBUSTIBLE', 'WWVFYY[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEAUTOS', 'FILTRO_SEGMENTO', 'WWSGYY[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEAUTOS', 'FILTRO_COLOR', 'WWVCYY[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEAUTOS', 'ORDEN', 'WWSOYY[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEAUTOS', 'PAGINA', 'WWPGYY[Value]');

INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'FILTRO_TIPO', 'autos-usados@QQnZ0');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'FILTRO_MARCA', '[Desc]@QQbrZ[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'FILTRO_MODELO', '[Desc]@QQmoZ[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'FILTRO_UBICACION', '[Desc]@QQreZ[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'FILTRO_ANIO', 'QQyZ[ValueDesde]+[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'FILTRO_KILOMETROS', 'QQkmZ[ValueDesde]+[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'FILTRO_PRECIO', 'QQpZ[ValueDesde]+[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'FILTRO_DIRECCION', 'QQsstZ[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'FILTRO_COMBUSTIBLE', 'QQfuelZ[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'FILTRO_TRANSMISION', 'QQtrZ[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'FILTRO_SEGMENTO', 'QQsgZ[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'FILTRO_PUERTAS', 'QQdZ[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'FILTRO_COLOR', 'QQcolZ[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'ORDEN', 'QQsortZ[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('DEMOTORES', 'PAGINA', 'QQpnZ[Value]');

INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'FILTRO_TIPO', 'ItemTypeID_[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'FILTRO_MARCA', '[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'FILTRO_MODELO', '[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'FILTRO_UBICACION', '_PciaId_[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'FILTRO_ANIO', '_YearRange_[ValueDesde]-[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'FILTRO_KILOMETROS', '_kilometers_[ValueDesde]-[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'FILTRO_PRECIO', '_PriceRange_[ValueDesde]-[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'FILTRO_DIRECCION', '_Direccion_[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'FILTRO_COMBUSTIBLE', '_Combustible_[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'FILTRO_TRANSMISION', '_Transmision_[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'FILTRO_PUERTAS', '_Cantidad-puertas_[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'FILTRO_COLOR', '_Color-exterior_[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'ORDEN', '_OrderId_[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('MERCADOLIBRE', 'PAGINA', '_Desde_[Value]');

INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('OLX', 'FILTRO_TIPO', 'autos-cat-[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('OLX', 'FILTRO_MARCA', '-carbrand_[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('OLX', 'FILTRO_MODELO', '-carmodel_[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('OLX', 'FILTRO_UBICACION', '[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('OLX', 'FILTRO_ANIO', '-year_[ValueDesde]_[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('OLX', 'FILTRO_KILOMETROS', '-kilometers_[ValueDesde]_[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('OLX', 'FILTRO_PRECIO', '-pricerange_[ValueDesde]_[ValueHasta]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('OLX', 'FILTRO_COMBUSTIBLE', '-fueltype_[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('OLX', 'FILTRO_TRANSMISION', '-transmission_[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('OLX', 'ORDEN', '-sort_[Value]');
INSERT INTO TB_ProviderComponenteUrl (CodProvider, CodComponente, Expresion) VALUES ('OLX', 'PAGINA', '-p-[Value]');
