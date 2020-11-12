using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class MontoRepository : GenericRepository<Monto>, IMontoRepository
    {

        public MontoRepository(GestionReclamosContext context) : base(context) { }

       
            

            //var response = from m in _context.Monto
            //               join reclamante in _context.Reclamante on m.IdReclamante equals reclamante.IdReclamante
            //               join ti in _context.TipoInstancia on m.IdInstancia equals ti.IdInstancia
            //               join ts in _context.TipoSituacion on m.IdSituacion equals ts.IdInstancia
            //               where ts.IdInstancia = m.id_instancia 
            //               join clp in _context.ClasePago on m.IdClasePago equals m.IdConcepto
            //               join 
            
        //SELECT m.importe, m.fecha_carga, m.id_estimacion, r.id_stro, r.txt_nombre, r.txt_dni,
        //    r.txt_domicilio, r.txt_vehiculo, r.txt_dominio, r.txt_dan_terceros, r.nro_reclamo,
        //    ti.id_instancia, ti.txt_descripcion, ts.id_situacion, ts.txt_descripcion,
        //    ts.sn_carga_monto, clp.id_clase_pago, clp.txt_descripcion, cp.id_concepto,
        //    cp.txt_descripcion, tm.id_tipo_monto, tm.txt_descripcion, u.id_usuario, u.nombre,
        //    m.cod_estim
        //FROM monto m  inner join reclamante r on r.id_reclamante= m.id_reclamante
        //    inner join tipo_instancia ti on ti.id_instancia= m.id_instancia
        //    inner join tipo_situacion ts on ts.id_situacion= m.id_situacion
        // AND   ts.id_instancia= m.id_instancia 
        // inner join clase_pago clp on  m.id_clase_pago= clp.id_clase_pago  
        // inner join concepto_pago cp on cp.id_concepto= m.id_concepto
        //    
        // AND m.id_clase_pago= cp.id_clase_pago
        //    inner join tipo_monto tm on tm.id_tipo_monto= m.id_tipo_monto
        //    inner join usuario u on u.id_usuario= m.id_usuario  where r.sn_activo= -1 and r.id_stro= 1
        //    order by m.id_instancia desc

        public  List<MontoCustomDTO> BuscarPagosPorIdSiniestroAPI(long? id_siniestro)
        {
            string CAMPOS_SQL = string.Empty;
            CAMPOS_SQL = "SELECT   m.importe, m.fecha_carga, m.id_estimacion, r.id_stro, r.txt_nombre, r.txt_dni, r.txt_domicilio, r.txt_vehiculo, "; //7
            CAMPOS_SQL = CAMPOS_SQL + " r.txt_dominio, r.txt_dan_terceros,r.nro_reclamo, ti.id_instancia, ti.txt_descripcion, "; //12
            CAMPOS_SQL = CAMPOS_SQL + " ts.id_situacion,ts.txt_descripcion, ts.sn_carga_monto, clp.id_clase_pago, clp.txt_descripcion,  "; //17
            CAMPOS_SQL = CAMPOS_SQL + " cp.id_concepto, cp.txt_descripcion, tm.id_tipo_monto, tm.txt_descripcion, u.id_usuario, u.nombre,m.cod_estim "; //23

            string sql = string.Empty;
            MontoCustomDTO monto = null;
            List<MontoCustomDTO> montos = null;
            SqlDataReader reader = null;
            try
            {

                using (SqlConnection conn = new SqlConnection("Server=localhost;Database=GestionReclamos4;Integrated Security = true"))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.Connection = conn;

                        sql = CAMPOS_SQL;
                        sql = sql + " FROM monto m ";
                        sql = sql + " inner join reclamante r on r.id_reclamante=m.id_reclamante ";
                        sql = sql + " inner join tipo_instancia ti on ti.id_instancia=m.id_instancia ";
                        sql = sql + " inner join tipo_situacion ts on ts.id_situacion=m.id_situacion and ts.id_instancia=m.id_instancia ";
                        sql = sql + " inner join clase_pago clp on m.id_clase_pago=clp.id_clase_pago ";
                        sql = sql + " inner join concepto_pago cp on cp.id_concepto=m.id_concepto and m.id_clase_pago=cp.id_clase_pago ";
                        sql = sql + " inner join tipo_monto tm on tm.id_tipo_monto=m.id_tipo_monto ";
                        sql = sql + " inner join usuario u on u.id_usuario=m.id_usuario ";
                        sql = sql + " where  r.sn_activo=-1 and r.id_stro=" + id_siniestro + " order by m.id_instancia desc";

                        command.CommandText = sql;
                        reader =  command.ExecuteReader();

                        /*
                         *  m.importe, m.fecha_carga, m.id_estimacion, r.id_stro, r.txt_nombre, r.txt_dni, r.txt_domicilio, r.txt_vehiculo
                            , r.txt_dominio, r.txt_dan_terceros,r.nro_reclamo, ti.id_instancia, ti.txt_descripcion,  ts.id_situacion
                         *   ,ts.txt_descripcion, ts.sn_carga_monto, clp.id_clase_pago, clp.txt_descripcion,  
                            cp.id_concepto, cp.txt_descripcion, tm.id_tipo_monto, tm.txt_descripcion, u.id_usuario, u.nombre
                         * */

                        montos = new List<MontoCustomDTO>();
                        while (reader.Read())
                        {
                            monto = new MontoCustomDTO();

                            monto.Importe = double.Parse(reader.GetDouble(0).ToString());
                            monto.FechaCarga = reader.GetDateTime(1);
                            monto.IdEstimacion = reader.GetInt64(2);
                            monto.Reclamante.IdStro= reader.GetInt64(3);
                            monto.IdStro = reader.GetInt64(3);
                            monto.Reclamante.TxtNombre = reader.GetString(4);
                            monto.Reclamante.TxtDni = reader.GetString(5);
                            monto.Reclamante.TxtDomicilio = reader.GetString(6);
                            monto.Reclamante.TxtVehiculo = reader.GetString(7);
                            monto.Reclamante.TxtDominio = reader.GetString(8);
                            monto.Reclamante.TxtDanTerceros = reader.GetString(9);
                            monto.Reclamante.NroReclamo = reader.GetInt64(10);
                            monto.Instancia.Id_instancia = reader.GetInt32(11);
                            monto.Instancia.Descripcion = reader.GetString(12);
                            monto.Situacion.Id_situacion = reader.GetInt32(13);
                            monto.Situacion.Descripcion = reader.GetString(14);
                            monto.Situacion.Sn_carga_monto = reader.GetInt32(15);
                            monto.ClasePago.IdClasePago = reader.GetInt32(16);
                            monto.ClasePago.TxtDescripcion = reader.GetString(17);
                            monto.Concepto.IdConcepto = reader.GetInt32(18);
                            monto.Concepto.TxtDescripcion = reader.GetString(19);
                            monto.TipoMonto.IdTipoMonto= reader.GetInt32(20);
                            monto.TipoMonto.TxtDescripcion = reader.GetString(21);
                            monto.Usuario.IdUsuario = reader.GetInt32(22);
                            monto.Usuario.Nombre = reader.GetString(23);
                            monto.CodEstim = reader.GetInt32(24);
                            montos.Add(monto);

                        }

                        return montos;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                montos = null;
                monto = null;
                if (reader != null)
                {
                    if (!reader.IsClosed)
                        reader.Close();
                    reader = null;

                }
            }
        }


    }
}
