using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcprojekamp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {
            var messagelist = mm.GetListInbox();
            return View(messagelist);
        }

        public ActionResult GetInboxDetails(int id)
        {
            var valuemessage = mm.GetByID(id);
            return View(valuemessage);
        }
        public ActionResult GetSendboxDetails(int id)
        {
            var valuemessage = mm.GetByID(id);
            return View(valuemessage);
        }
        public ActionResult SendBox()
        {
            var messagelist = mm.GetListSendbox();
            return View(messagelist);
        }
        [HttpGet]
        public ActionResult GetDraftDetails(int id)
        {
            var valuemessage = mm.GetByID(id);
            return View(valuemessage);
        }

        [HttpPost]
        public ActionResult GetDraftDetails(Message message)
        {
            ValidationResult validationResult = messagevalidator.Validate(message);
            if (validationResult.IsValid)
            {
                message.SenderMail = "admin@admin.com";
                message.DraftMessage = true;
                message.MessageDate = DateTime.Now;
                mm.MessageAdd(message);
                return RedirectToAction("SenBox");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public PartialViewResult PartialSendCountResult()
        { var messageCount = mm.GetListSendbox();
            return PartialView(messageCount);
        }

        public PartialViewResult PartialInCountResult()
        {
            var messageCount = mm.GetListInbox();
            return PartialView(messageCount);
        }
        public PartialViewResult PartialDraftCountResult()
        {
            var messageCount = mm.GetDraftMessage();
            return PartialView(messageCount);
        } 

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult validationResult = messagevalidator.Validate(message);
            if (validationResult.IsValid)
            {
                
                message.MessageDate = DateTime.Now;
                mm.MessageAdd(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DraftMessage()
        {
            var messagelist = mm.GetDraftMessage();
            return View(messagelist);
        }
    }
}