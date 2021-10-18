using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace simpleCRUD
{
    class Orden
    {
        //propiedades
        public int _OrdenId { get; set; }
        public string _Fecha { get; set; }
        public string _Descripcion { get; set; }
     
        

        //instancia a la clase Crud
        private Crud crud = new Crud();

        //metodo para retornar los registros de la tabla Book
        public MySqlDataReader getAllOrden()
        {
            string query = "SELECT Id,Fecha,Descripcion";

            //llamado al metodo select de la clase Crud
            return crud.select(query);
        }

        //metodo para insertar o editar un registro
        public Boolean newEditOrden(string action)
        {
            if (action == "new")
            {
                string query = "INSERT INTO Orden(Id, Fecha, Descripcion)" +
                    "VALUES ('" + _OrdenId + "', '" + _Fecha + "', '" + _Descripcion + "', '" ;
                crud.executeQuery(query); //llamato al metodo executeQuery de la clase Crud
                return true;
            }
            else if (action == "edit")
            {
                string query = "UPDATE Orden SET "
                    + "Id='" + _OrdenId + "' ,"
                    + "Fecha='" + _Fecha + "',"
                    + "Descripcion='" + _Descripcion + "',"
                    +  "'"
                    + "WHERE "
                    + "OrdenId='" + _OrdenId + "'";
                crud.executeQuery(query);
                return true;
            }

            return false;
        }

        //metodo para eliminar
        public Boolean deleteOrden()
        {
            string query = "DELETE FROM Orden WHERE OrdenId='" + _OrdenId + "'";
            crud.executeQuery(query);
            return true;
        }
    }
}