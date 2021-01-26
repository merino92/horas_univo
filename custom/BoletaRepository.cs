using System;
using univo.data;
using univo.JsonModel.boleta;
using univo.Models;

namespace univo.custom
{
    public class BoletaRepository
    {
        private readonly univoContext context=null;
        public BoletaRepository(univoContext ct){
            context = ct;
        } 

        private string createCodigo(DateTime fecha,int boletaid,int idusuario){
            string format = fecha.ToString("yyyyMMddHHmmss");
            return (Convert.ToString(boletaid)+format);
        }//retorna el codigo autogenerado
        /*public int create(boletajson bo,int idusuario){
            try{
                DateTime fecha = DateTime.Now;
                using(var transaccion=context.Database.BeginTransaction()){
                    var boleta = new Boletas{
                        fecha= fecha,
                        codigo="",
                        idusuario=idusuario,
                        encargado=bo.encargado,
                        detalle=bo.detalle,

                    };
                }
            }catch(Exception e){
                throw new Exception(e.Message);
            }
        }*/
    }
}