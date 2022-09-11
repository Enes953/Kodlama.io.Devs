using Application.Features.Githubs.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Models
{
    public class GithubListModel:BasePageableModel
    {
        public List<GithubListDto> Items { get; set; }
    }
}
