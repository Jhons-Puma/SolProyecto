using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolProyecto.CustomExtensions;
using SolProyecto.DataAccess;
using SolProyecto.DataAccess.DBEntities;
using SolProyecto.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace SolProyecto.Controllers
{
    public class CarritoCompraController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ProyectoContext _context;
        public CarritoCompraController
            (
            ProyectoContext context, 
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult CatalogoProducto()
        {
            var listaProducto = _context.TbProducto.Where(c=>c.estado == true).ToList();
            var lista = _mapper.Map<List<ProductoCatalogoModel>>(listaProducto);
            return View(lista);
        }

        public IActionResult DetalleCatalogo(int id)
        {
            var productById = _context.TbProducto.Where(c => c.id == id && c.estado == true).SingleOrDefault();
            var productInView = _mapper.Map<ProductoCatalogoModel>(productById);
            return View(productInView);
        }


        [HttpPost]
        public JsonResult AddTemporalProduct(ProductTemporalModel param)
        {
            //CARGAMOS INFO DEL PRODUCTO QUE INTENTAMOS AÑADIR AL CARRITOP
            var productById = _context.TbProducto.Where(c => c.id == param.Id && c.estado == true).SingleOrDefault();
            param.Nombre = productById.marca;
            param.Precio = productById.precioFinal.Value;
            param.ImageURL = productById.imgURL;

            //LISTA DE PRODUCTOS (TODOS) QUEESTAN EN EL CARRITO
            List<ProductTemporalModel> temporalProductos = null; //new List<ProductTemporalModel>();

            if (HttpContext.Session.GetList<ProductTemporalModel>("temporal") == null) {
                temporalProductos = new List<ProductTemporalModel>();
            }
            else
            {
                temporalProductos = (List<ProductTemporalModel>)HttpContext.Session.GetList<ProductTemporalModel>("temporal");
            }
            temporalProductos.Add(param);
            HttpContext.Session.Set<List<ProductTemporalModel>>("temporal", temporalProductos);
            return new JsonResult(new { a = 1 });
        }

        public IActionResult ConfirmaCompra()
        {
            var model = new ConfirmarCarritoCompraModel();
            model.TemporalProducts = (List<ProductTemporalModel>)HttpContext.Session.GetList<ProductTemporalModel>("temporal");
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveShoppingCard(ConfirmarCarritoCompraModel modelToSave)
        {
            modelToSave.TemporalProducts = (List<ProductTemporalModel>)HttpContext.Session.GetList<ProductTemporalModel>("temporal");

            //GRABAR CLIENTE
            var cliente = _context.TbCliente.Add(new ClienteEntity() {
                numeroDocumento = modelToSave.numeroDocumento,
                nombre = modelToSave.nombre,
                apellido = modelToSave.apellido,
                correo = modelToSave.correo,
                clave = modelToSave.clave,
                estado = true,
            
            });

            //GRABAR ORDEN
            _context.TbPedido.Add(new PedidosEntity()
            {
                tarjetaCredito = modelToSave.tarjetaCredito,
                fechaVenCredito = modelToSave.fechaVenCredito,
                CVV = modelToSave.CVV,
                email = modelToSave.email,
                fechaOrden = DateTime.Now,
                estado = true
            });

            // GRABAR PRODUCTOS
            foreach (var item in modelToSave.TemporalProducts)
            {
                _context.TbDetallePedido.Add(new DetallePedidosEntity()
                {
                    estado = true,
                    precioFinal = item.Precio
                });
            }


            _context.SaveChanges();



            return View();
        }
    }
}
 