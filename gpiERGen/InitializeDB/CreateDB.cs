
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using GpiERGenNHibernate.EN.GpiER;
using GpiERGenNHibernate.CEN.GpiER;
using GpiERGenNHibernate.CAD.GpiER;
using GpiERGenNHibernate.Enumerated.GpiER;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\SQLEXPRESS; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                /*List<GpiERGenNHibernate.EN.Mediaplayer.MusicTrackEN> musicTracks = new List<GpiERGenNHibernate.EN.Mediaplayer.MusicTrackEN>();
                 * GpiERGenNHibernate.EN.Mediaplayer.UserEN userEN = new GpiERGenNHibernate.EN.Mediaplayer.UserEN();
                 * GpiERGenNHibernate.EN.Mediaplayer.ArtistEN artistEN = new GpiERGenNHibernate.EN.Mediaplayer.ArtistEN();
                 * GpiERGenNHibernate.EN.Mediaplayer.MusicTrackEN musicTrackEN = new GpiERGenNHibernate.EN.Mediaplayer.MusicTrackEN();
                 * GpiERGenNHibernate.CEN.Mediaplayer.ArtistCEN artistCEN = new GpiERGenNHibernate.CEN.Mediaplayer.ArtistCEN();
                 * GpiERGenNHibernate.CEN.Mediaplayer.UserCEN userCEN = new GpiERGenNHibernate.CEN.Mediaplayer.UserCEN();
                 * GpiERGenNHibernate.CEN.Mediaplayer.MusicTrackCEN musicTrackCEN = new GpiERGenNHibernate.CEN.Mediaplayer.MusicTrackCEN();
                 * GpiERGenNHibernate.CEN.Mediaplayer.PlayListCEN playListCEN = new GpiERGenNHibernate.CEN.Mediaplayer.PlayListCEN();
                 *
                 *              //Add Users
                 * userEN.Email = "user@user.com";
                 * userEN.Name = "user";
                 * userEN.Surname = "userSurname";
                 * userEN.Password = "user";
                 * userCEN.New_(userEN.Name, userEN.Surname, userEN.Email, userEN.Password);
                 *
                 * //Add Music Track1
                 * musicTrackEN.Id = "http://www2.b3ta.com/mp3/Beer Beer Beer (YOB mix).mp3";
                 * musicTrackEN.Format = "mp3";
                 * musicTrackEN.Lyrics = "Beer Beer Beer Beer Beer Beer ..";
                 * musicTrackEN.Name = "Beer Beer Beer";
                 * musicTrackEN.Company = "Company";
                 * musicTrackEN.Cover = "http://www.tomasabraham.com.ar/cajadig/2007/images/nro18-2/beer1.jpg";
                 * musicTrackEN.Price = 20;
                 * musicTrackEN.Rating = 5;
                 * musicTrackEN.CommunityRating = 5;
                 * musicTrackEN.Duration = 200;
                 * musicTrackCEN.New_(musicTrackEN.Id, musicTrackEN.Format, musicTrackEN.Lyrics, musicTrackEN.Name,
                 *  musicTrackEN.Company, musicTrackEN.Cover, musicTrackEN.CommunityRating, musicTrackEN.Rating,
                 *  musicTrackEN.Price, musicTrackEN.Duration);
                 * musicTracks.Add(musicTrackEN);
                 * musicTrackCEN.AsignUser(musicTrackEN.Id,userEN.Email);
                 *
                 * //Define Album
                 * //GpiERGenNHibernate.CEN.Mediaplayer.AlbumCEN albumCEN = new GpiERGenNHibernate.CEN.Mediaplayer.AlbumCEN();
                 * //albumCEN.New_("Album 1", "This is a Album 1", artists, musicTracks);*/

                // ------------------------- Insertar Cliente ---------------------------

                ClienteEN cli1 = new ClienteEN ();

                cli1.Nif = "12345678A";
                cli1.Email = "cliente1@cliente.com";
                cli1.Nombre = "Cliente1";
                cli1.Telefono = "654321789";
                cli1.Pais = "España";
                cli1.Provincia = "Albacete";
                cli1.RiesgosPermitidos = 500;
                cli1.TipoDescuento = TipoDescuentoEnum.TIPO_1;
                cli1.Descuento = 1;
                IList<DateTime?  > dias = new List<DateTime?  >();
                dias.Add (new DateTime (2015, 2, 3));
                dias.Add (new DateTime (2015, 3, 5));
                cli1.DiasPago = dias;
                cli1.Direccion = "Calle Mayor nº 22, Albacete";
                cli1.DireccionEnvio = "Calle Mayor nº 22, Albacete";
                cli1.FechaAlta = new DateTime (2015, 04, 09);
                cli1.FechaUltimaModificacion = new DateTime (2015, 04, 09);
                cli1.DatosContables = "";
                cli1.DatosBancarios = "333333333333333";
                ClienteCEN cliCen = new ClienteCEN ();

                cliCen.NuevoCliente (cli1.Nif, cli1.Nombre, cli1.Pais, cli1.Provincia, cli1.Direccion, cli1.Email, cli1.DatosBancarios, cli1.DiasPago, cli1.TipoDescuento, cli1.Descuento, cli1.RiesgosPermitidos, cli1.DatosContables, cli1.DireccionEnvio, cli1.FechaAlta, cli1.FechaUltimaModificacion, cli1.Telefono);


                ClienteEN cli2 = new ClienteEN ();

                cli2.Nif = "11111111D";
                cli2.Email = "cliente2@cliente.com";
                cli2.Nombre = "Cliente2";
                cli2.Telefono = "655112233";
                cli2.Pais = "España";
                cli2.Provincia = "Barcelona";
                cli2.RiesgosPermitidos = 1720;
                cli2.TipoDescuento = TipoDescuentoEnum.TIPO_2;
                cli2.Descuento = 2;
                dias.Clear ();
                dias = new List<DateTime?  >();
                dias.Add (new DateTime (2014, 8, 10));
                dias.Add (new DateTime (2015, 1, 11));
                cli2.DiasPago = dias;
                cli2.Direccion = "Calle Tomate nº 10, Barcelona";
                cli2.DireccionEnvio = "Calle de GPI nº 4, Barcelona";
                cli2.FechaAlta = DateTime.Now;
                cli2.FechaUltimaModificacion = DateTime.Now;
                cli2.DatosContables = "";
                cli2.DatosBancarios = "22222222222222";

                cliCen.NuevoCliente (cli2.Nif, cli2.Nombre, cli2.Pais, cli2.Provincia, cli2.Direccion, cli2.Email, cli2.DatosBancarios, cli2.DiasPago, cli2.TipoDescuento, cli2.Descuento, cli2.RiesgosPermitidos, cli2.DatosContables, cli2.DireccionEnvio, cli2.FechaAlta, cli2.FechaUltimaModificacion, cli2.Telefono);




                // ------------------------- Insertar Proveedor ---------------------------

                ProveedorEN pro1 = new ProveedorEN ();

                pro1.Nif = "12345678C";
                pro1.Email = "proveedor1@proveedor.com";
                pro1.Nombre = "Proveedor1";
                pro1.Telefono = "654321789";
                pro1.Pais = "Francia";
                pro1.Provincia = "Le Mans";
                pro1.Divisa = DivisaEnum.EURO;
                pro1.Direccion = "Calle Francia nº 45";
                pro1.Descuento = 1;
                pro1.DatosBancarios = "000000000000";
                dias.Clear ();
                dias.Add (new DateTime (2013, 1, 2));
                dias.Add (new DateTime (2015, 3, 4));
                pro1.DiasCobro = dias;


                pro1.FechaAlta = new DateTime (2015, 04, 09);
                pro1.FechaUltimaModificacion = pro1.FechaAlta;

                pro1.Direccion = "Dirección de la sede del proveedor1";


                ProveedorCEN proCen = new ProveedorCEN ();

                proCen.NuevoProveedor (pro1.Nif, pro1.Nombre, pro1.Pais, pro1.Provincia, pro1.Direccion, pro1.Email, pro1.Divisa, pro1.DatosBancarios, pro1.Descuento, pro1.DiasCobro, pro1.FechaAlta, pro1.FechaUltimaModificacion, pro1.Telefono);




                ProveedorEN pro2 = new ProveedorEN ();

                pro2.Nif = "22556644H";
                pro2.Email = "proveedor2@proveedor.com";
                pro2.Nombre = "Proveedor2";
                pro2.Telefono = "658787811";
                pro2.Pais = "España";
                pro2.Provincia = "Alicante";
                pro2.Divisa = DivisaEnum.EURO;
                pro2.Direccion = "Avd Madrid nº 1, Benidorm";
                pro2.Descuento = 5;
                pro2.DatosBancarios = "111111111111";
                dias.Clear ();
                dias.Add (new DateTime (2014, 7, 8));
                dias.Add (new DateTime (2015, 4, 11));
                pro2.DiasCobro = dias;


                pro2.FechaAlta = new DateTime (2015, 04, 09);
                pro2.FechaUltimaModificacion = new DateTime (2015, 5, 10);

                pro2.Direccion = "Dirección de la sede del proveedor2";


                proCen.NuevoProveedor (pro2.Nif, pro2.Nombre, pro2.Pais, pro2.Provincia, pro2.Direccion, pro2.Email, pro2.Divisa, pro2.DatosBancarios, pro2.Descuento, pro2.DiasCobro, pro2.FechaAlta, pro2.FechaUltimaModificacion, pro2.Telefono);


                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
