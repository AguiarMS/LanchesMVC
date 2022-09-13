using LanchesMVC.Models;
using LanchesMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMVC.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItems();

            //Teste colocando dois itens no carrinho
            //var itens = new List<CarrinhoCompraItem>()
            //{
            //   new CarrinhoCompraItem(),
            //   new CarrinhoCompraItem()
            // };

            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }
    }
}
