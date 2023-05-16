using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIproject.Entity;
using APIproject.Interfaces;
using APIproject.Models;
using APIproject.Services;
using System.Net;

namespace APIproject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly ProductManagmentContext _context;
        private readonly IPackageService _packageService;

        public PackageController(ProductManagmentContext context, IPackageService packageService)
        {
            _context = context;
            _packageService = packageService;
        }


        [HttpPost("createPackage")]
        public CreatePackageResponse CreatePackage(CreatePackageRequest createRequest) => _packageService.CreatePackage(createRequest);

        [HttpGet("getPackage")]
        public GetPackageResponse GetPackage(GetPackageRequest getRequest) => _packageService.GetPackage(getRequest);

        [HttpPut("updatePackage")]
        public UpdatePackageResponse UpdatePackage(UpdatePackageRequest updateRequest) => _packageService.UpdatePackage(updateRequest);

        [HttpDelete("deletePackage")]
        public DeletePackageResponse DeletePackage(DeletePackageRequest deleteRequest) => _packageService.DeletePackage(deleteRequest);

        
    }


}
