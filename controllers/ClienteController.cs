using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultasMVC.Models.Dao;
using ConsultasMVC.Models.Dto;
using ConsultasMVC.Views;

namespace ConsultasMVC.controllers
{
    class ClienteController
    {
        ClienteView vista;
        public ClienteController(ClienteView View)
        {
            vista = View;
            vista.Load += new EventHandler(ClientList);
            vista.btnBuscar.Click += new EventHandler(ClientList);
            vista.txtBuscar.TabIndexChanged += new EventHandler(ClientList);
        }
        private void ClientList(object sender, EventArgs e)
        {
            ClienteDao db = new ClienteDao();
            vista.TablaCliente.DataSource = db.VerRegistros(vista.txtBuscar.Text);
        }
    }
}
