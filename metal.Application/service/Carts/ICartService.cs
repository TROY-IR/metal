using metal.Application.InterFace.Contexts;
using metal.Common;
using metal.Domain.Entities.Carts;
using metal.Domain.Entities.commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.Carts
{
    public interface ICartService
    {
        ResultDto AddToCart(long? ProductId, Guid BrowserId, dCartItemdto? dcart);
        ResultDto RemoveFromCart(long ProductId, Guid BrowserId);
        ResultDto<CartDto> GetMyCart(Guid BrowserId, long? UserId);

        ResultDto Add(long CartItemId);
        ResultDto LowOff(long CartItemId);
    }

    public class CartService : ICartService
    {
        private readonly IDataBaseContext _context;
        public CartService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Add(long CartItemId)
        {
            var cartItem = _context.cartItems.Find(CartItemId);
            cartItem.Count++;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
            };
        }

        public ResultDto AddToCart(long? ProductId, Guid BrowserId,dCartItemdto? dcart)
        {
            var cart = _context.carts.Where(p => p.BrowserId == BrowserId && p.Finished == false).FirstOrDefault();
            if (cart == null)
            {
                Cart newCart = new Cart()
                {
                    Finished = false,
                    BrowserId = BrowserId,
                };
                _context.carts.Add(newCart);
                _context.SaveChanges();
                cart = newCart;
            }

            if (ProductId != null)
            {
            var product = _context.Products.Find(ProductId);

            var cartItem = _context.cartItems.Where(p => p.ProductId == ProductId && p.CartId == cart.Id).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Count++;
            }
            else
            {
                CartItem newCartItem = new CartItem()
                {
                    Cart = cart,
                    Count = 1,
                    Price = product.Price,
                    Product = product,

                };
                _context.cartItems.Add(newCartItem);
                _context.SaveChanges();
            }
            }
            else
            {
                int? sizep = _context.sizes.Where(p => p.msize == dcart.size).FirstOrDefault().Price;
                int? texrap = _context.texras.Where(p => p.mtexra == dcart.txchra).FirstOrDefault().Price;
                dCartItem dCart = new dCartItem()
                {
                    Cart = cart,
                    tozih = dcart.tozih,
                    imsrc = dcart.imsrc,
                    Count = dcart.Count,
                    size = dcart.size,
                    txchra = dcart.txchra,
                    Price = dcart.Count * 79 + sizep + texrap
                    
                };
                _context.dCartItems.Add(dCart);
                _context.SaveChanges();
            }


            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"محصول با موفقیت به سبد خرید شما اضافه شد ",
            };
        }

        public ResultDto<CartDto> GetMyCart(Guid BrowserId, long? UserId)
        {

                var cart = _context.carts
                    .Include(p => p.CartItems)
                    .Include(p => p.dCartItems)
                    .Where(p => p.BrowserId == BrowserId && p.Finished == false)
                    .OrderByDescending(p => p.Id)
                    .FirstOrDefault();

                if (cart == null)
                {
                    return new ResultDto<CartDto>()
                    {
                        Data = new CartDto()
                        {
                            CartItems = new List<CartItemDto>(),

                        },
                    };
                }

                if (UserId != null)
                {
                    var user = _context.Users.Find(UserId);
                    cart.User = user;
                    _context.SaveChanges();
                }
            var cartit = cart.CartItems;
            var dcartit = cart.dCartItems;
            CartDto da = new CartDto()
            {
                ProductCount = cart.CartItems.Count(),
                SumAmount = cart.CartItems.Sum(p => p.Price * p.Count),
                CartId = cart.Id,
                CartItems = cartit.Select(p => new CartItemDto
                {
                    Count = p.Count,
                    Price = p.Price,
                    Product = _context?.Products?.FirstOrDefault(x => x.Id == p.ProductId)?.Name,
                    Id = p.Id,
                    Images = _context?.Products?.Find(p.ProductId)?.ProductImages?.FirstOrDefault()?.Src,
                }).ToList(),
                dCartItems = dcartit.Select(p => new dCartItemdto
                {
                    id = p.Id,
                    Price = p.Price,
                    imsrc = p.imsrc,
                    Count = p.Count,
                    size = p.size,
                    tozih = p.tozih,
                    txchra = p.txchra,
                    Cart = cart,
                }).ToList()
            };
                return new ResultDto<CartDto>()
                {
                    Data = da,
                    IsSuccess = true,
                };
            }


        

        public ResultDto LowOff(long CartItemId)
        {
            var cartItem = _context.cartItems.Find(CartItemId);

            if (cartItem.Count <= 1)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                };
            }
            cartItem.Count--;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
            };
        }

        public ResultDto RemoveFromCart(long ProductId, Guid BrowserId)
        {
            var cartitem = _context.cartItems.Where(p => p.Cart.BrowserId == BrowserId).FirstOrDefault();
            if (cartitem != null)
            {
                cartitem.IsRemoved = true;
                cartitem.RemoveTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول از سبد خرید شما حذف شد"
                };

            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "محصول یافت نشد"
                };
            }
        }

    }

    public class CartDto
    {
        public long CartId { get; set; }
        public int ProductCount { get; set; }
        public int SumAmount { get; set; }
        public List<CartItemDto> CartItems { get; set; }
        public List<dCartItemdto> dCartItems { get; set; }
    }

    public class CartItemDto
    {
        public long Id { get; set; }
        public string? Product { get; set; }
        public string Images { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
    public class dCartItemdto
    {
        public long? id { get; set; }
        public int? Price { get; set; }
        public virtual Cart? Cart { get; set; }
        public string tozih { get; set; } 
        public string imsrc { get; set; } 
        public string? size { get; set; } 
        public string? txchra { get; set; }
        public int? Count { get; set; } = 1;


    }
}
