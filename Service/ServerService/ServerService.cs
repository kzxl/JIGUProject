using Microsoft.EntityFrameworkCore;
using ModelDTO;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.ServerService
{
    public class ServerService : IServerService
    {
        private readonly dbContext _context;
        public ServerService(dbContext context)
        { _context = context; }

        public async Task<List<LineInfo>> GetData()
            => await _context.LineInfo.ToListAsync();

        public ResponseDTO SetCF(RequestDTO request)
        {
            try
            {
                _context.LineInfo.Add(new LineInfo
                {
                    Line = request.Line,
                    CF = request.CF,
                    Code = request.CODE,
                    Quantity = request.Quantity,
                    Date = DateTime.Now
                });
                _context.SaveChanges();
                return new ResponseDTO { IsSuccess = true, Message = "Thêm thành công" };
            }
            catch (Exception ex) { return new ResponseDTO { IsSuccess = false, Message = ex.Message }; }
        }
        public ResponseDTO DeleteCF(int id)
        {
            try
            {
                var cf = _context.LineInfo.FirstOrDefault(s => s.Id == id);
                if (cf == null)
                {
                    return new ResponseDTO { IsSuccess = false, Message = "Không tìm thấy" };
                }
                _context.LineInfo.Remove(cf);
                _context.SaveChanges();
                return new ResponseDTO { IsSuccess = true, Message = "Xóa thành công" };
            }
            catch (Exception ex) { return new ResponseDTO { IsSuccess = false, Message = ex.Message }; }

        }
    }
}
