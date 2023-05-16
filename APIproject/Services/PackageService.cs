using APIproject.Interfaces;
using APIproject.Models;
using Microsoft.EntityFrameworkCore;
using APIproject.Mapping;
using APIproject.Entity;
using APIproject;
using System.Security.Cryptography.X509Certificates;

namespace APIproject.Services
{
    public class PackageService
    {
        private readonly ProductManagmentContext _context;
        private readonly IPackageMapper<Package, PackageModel> _packageMapper;

        public PackageService(ProductManagmentContext context)
        {
            _context = context;
            _packageMapper = new PackageMapper();
        }

        public CreatePackageResponse CreatePackage(PackageModel package)
        {
            var packageAlreadyExist=_context.packages.Any(p => p.ID == package.ID);
            if (packageAlreadyExist)
            {
                throw new DbUpdateException( $"this ID{package.ID} already exist" );
            }

            var packageEntity = _packageMapper.mapFromModleToEntityPackage(package);
            var newPackage=_context.packages.Add(packageEntity);
            _context.SaveChanges();

            return new CreatePackageResponse { PackageCreate = package };
        }
      
        public GetPackageResponse GetPackage(GetPackageRequest package)
        {
            var newPackage = _context.packages.Find(package.ID);
            return new GetPackageResponse { PackageGet=_packageMapper.mapFromEntityToModelPackage(newPackage) };
        }

        public UpdatePackageResponse UpdatePackage(UpdatePackageRequest package)
        {
            var existingPackageToUpdate = _context.packages.Find(package.PackageToUpdate.ID);
            if (existingPackageToUpdate == null)
            {
                throw new DbUpdateException($"there is no suck ID");
            }

            _packageMapper.mapFromModleToEntityPackage(package.PackageToUpdate, existingPackageToUpdate);
            _context.SaveChanges();
            return new UpdatePackageResponse { updatePackage=package.PackageToUpdate };
        }

        public DeletePackageResponse DeletePackage(DeletePackageRequest package)
        {
            var newPackage=_context.packages.Find(package.ID);
            if (newPackage == null)
            {
                throw new DbUpdateException($"this Id{package.ID} does not exist");
            }
            _context.packages.Remove(newPackage);
            _context.SaveChanges();
            return new DeletePackageResponse { IsDeleted=true };
        }
    }
    
}
