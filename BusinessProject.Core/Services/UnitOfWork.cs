using BusinessProject.Core.Interfaces;
using BusinessProject.DataModelLayer.DbContext;
using BusinessProject.DataModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.Core.Services
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        private GenericClasses<SystemUsers> _userManager;
        private GenericClasses<SystemRoles> _roleManager;
        private GenericClasses<SystemJobs> _jobManger;
        private GenericClasses<UserJob> _userJob;
        private GenericClasses<Payment> _payment;
        private GenericClasses<RolePattern> _rolePattern;
        private GenericClasses<RolePatternDetails> _rolePatternDetails;
        private GenericClasses<Contract> _contract;
        private GenericClasses<Letter> _letter;
        private GenericClasses<AdminstrativeForm> _adminstrativeForm;

        // It is for AdminstrativeForm 
        public GenericClasses<AdminstrativeForm> adminstrativeFormUW
        {
            get
            {
                if (_adminstrativeForm == null)
                {
                    _adminstrativeForm = new GenericClasses<AdminstrativeForm>(_context);
                }
                return _adminstrativeForm;
            }
        }


        // It is for Letter 
        public GenericClasses<Letter> letterUW
        {
            get
            {
                if (_letter == null)
                {
                    _letter = new GenericClasses<Letter>(_context);
                }
                return _letter;
            }
        }

        // It is for Contract 
        public GenericClasses<Contract> contractUW
        {
            get
            {
                if (_contract == null)
                {
                    _contract = new GenericClasses<Contract>(_context);
                }
                return _contract;
            }
        }

        // It is for RolePatternDetails 
        public GenericClasses<RolePatternDetails> rolePatternDetailsUW
        {
            get
            {
                if (_rolePatternDetails == null)
                {
                    _rolePatternDetails = new GenericClasses<RolePatternDetails>(_context);
                }
                return _rolePatternDetails;
            }
        }

        // It is for RolePattern 
        public GenericClasses<RolePattern> rolePatternUW
        {
            get
            {
                if (_rolePattern == null)
                {
                    _rolePattern = new GenericClasses<RolePattern>(_context);
                }
                return _rolePattern;
            }
        }

        // It is for payment 
        public GenericClasses<Payment> paymentUW
        {
            get
            {
                if (_payment == null)
                {
                    _payment = new GenericClasses<Payment>(_context);
                }
                return _payment;
            }
        }

        // It is for UserJob 
        public GenericClasses<UserJob> userJobUW
        {
            // read only
            get
            {
                if (_userJob == null)
                {
                    _userJob = new GenericClasses<UserJob>(_context);
                }
                return _userJob;
            }
        }

        // It is for _jobManger 
        public GenericClasses<SystemJobs> JobanagerUW
        {
            // read only
            get
            {
                if (_jobManger == null)
                {
                    _jobManger = new GenericClasses<SystemJobs>(_context);
                }
                return _jobManger;
            }
        }

        // It is for System Roles
        public GenericClasses<SystemRoles> roleManagerUW
        {
            // read only
            get
            {
                if (_roleManager == null)
                {
                    _roleManager = new GenericClasses<SystemRoles>(_context);
                }
                return _roleManager;
            }
        }

        // It is for System Users
        public GenericClasses<SystemUsers> userManagerUW
        {
            // read only
            get
            {
                if (_userManager == null)
                {
                    _userManager = new GenericClasses<SystemUsers>(_context);
                }
                return _userManager;
            }
        }

        public IEntityDatabaseTransaction BeginTrasaction()
        {
            return new EntityDatabaseTransaction(_context);
        }
        public void save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
