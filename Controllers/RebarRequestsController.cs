using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmallStructuresTakeOffs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallStructuresTakeOffs.Controllers
{
    public class RebarRequestsController : Controller
    {
        #region Context Setup
        private readonly EFCoreDBcontext _context;

        public object rebarfabricated { get; private set; }

        public RebarRequestsController(EFCoreDBcontext context)
        {
            _context = context;
        }
        #endregion

        #region Rebar Request List (Index Action)
        // GET: RebarRequestsController
        public ActionResult Index(long id)
        {
            var RebLengthList =
                from l in typeof(RebarLengths).GetFields()
                select l;


            ViewBag.RebarLgthList = new SelectList(RebLengthList, "RebarLengths");
            //var ResList = repository.GetResourceList(id);
            //ViewBag.RebarLgthList = new SelectList(RebLengthList, "ResourceVMId", "ResourceVMCombined");

            var RebLList = new { RebarLengths.RebLength8, RebarLengths.RebLength16, RebarLengths.RebLength20, RebarLengths.RebLength30, RebarLengths.RebLength40 };


            ViewBag.RebarLengths = new SelectList(RebLList.ToString(), "RebLList");



            ViewBag.ProjectId = id;
            return View(_context.RebarRequests.Where(w => w.RebReqProjId == id).ToList());
        }
        #endregion

        #region Details Action (Not used)
        // GET: RebarRequestsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        #endregion

        #region Create Request Action
        // GET: RebarRequestsController/Create
        public ActionResult Create(long id)
        {
            ViewBag.ProjectId = id;

            var rNom =
                    Enum.GetValues(typeof(RebarNomination));
            ViewBag.RebNomination = new SelectList(rNom, "RebarRequestNomination");

            return View();
        }

        // POST: RebarRequestsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RebarRequest request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = request.RebReqProjId });
            }
            return View();
        }

        #endregion

        #region Edit Request Action
        // GET: RebarRequestsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.RebReqId = id;
            var rNom =
                Enum.GetValues(typeof(RebarNomination));
            ViewBag.RebNomination = new SelectList(rNom, "RebarRequestNomination");

            return View(_context.RebarRequests.Where(w => w.RebarRequestId == id).FirstOrDefault());
        }

        // POST: RebarRequestsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RebarRequest request)
        {
            if (ModelState.IsValid)
            {
                _context.Update(request);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = request.RebReqProjId });
            }
            return View();
        }
        #endregion

        #region Delete Request Action
        // GET: RebarRequestsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.RebarRequests.Where(s => s.RebarRequestId == id).FirstOrDefault());
        }

        // POST: RebarRequestsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int rebarRequestId)
        {

            long proj = _context.RebarRequests.Where(w => w.RebarRequestId == rebarRequestId).Select(s => s.RebReqProjId).FirstOrDefault();
            RebarRequest rr = _context.RebarRequests.Where(w => w.RebarRequestId == rebarRequestId).FirstOrDefault();
            _context.RebarRequests.Remove(rr);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), new { id = proj });
        }
        #endregion

        #region Results Display
        public ActionResult Results(long id, string length)
        {
            ViewBag.ProjectId = id;

            string nomLength = length;

            var purchasesQ =
                from q in MyMethods.purchases
                select q;

            ViewData["purchasesM"] = purchasesQ;

            MyMethods.ClearWaste(_context);

            #region Ordering RebarRequest by Nom, Length (It Works!, commented out)
            var RebarRequestsSorted =
                from p in _context.RebarRequests.AsEnumerable()
                where p.RebReqProjId == id
                group p by p.RebarRequestNomination into req
                orderby req.Key
                select req;

            decimal AllReqWeight = 0;
            Console.WriteLine($"REQUESTING");
            foreach (var r in RebarRequestsSorted)
            {
                decimal totalLength = 0;
                decimal totalweight = 0;

                foreach (var q in r.OrderByDescending(o => o.RebarRequestLength))
                {

                    //try
                    {
                        Console.WriteLine($"ReqNo. {q.RebarRequestId}, \t{q.RebarRequestNomination}, \t{q.RebarRequestLength} ft/ea, \t{q.RebarRequestQty} ea,  \t{q.RebarRequestLength * q.RebarRequestQty} Length");

                        totalLength += q.RebarRequestLength * q.RebarRequestQty;
                        totalweight += q.RebarRequestLength * q.RebarRequestQty * MyMethods.rInfo.Find(s => s.rNom == q.RebarRequestNomination.ToString()).rWeigth;
                        AllReqWeight += q.RebarRequestLength * q.RebarRequestQty * MyMethods.rInfo.Find(s => s.rNom == q.RebarRequestNomination.ToString()).rWeigth;
                        MyMethods.PurchasesAdd(q.RebarRequestNomination, q.RebarRequestLength, q.RebarRequestQty, q.RebarRequestId, q.RebReqProjId, _context, q.Structure, RebarLengths.RebLength20);
                    }

                    //catch (InvalidOperationException e)
                    //{
                    //    Console.WriteLine($"No Elements {e}");
                    //}
                }

                Console.WriteLine($"\t\t\t\tTotal Requested Length: {r.Key}, {totalLength} ft");
                Console.WriteLine($"\t\t\t\tTotal Requested Weight: {r.Key}, {totalweight} lb");
            }

            Console.WriteLine($"\t\t\t\tTotal Requested Weight: AllNoms, {AllReqWeight} lb");

            //Console.WriteLine($"\t\t\t\tTotal Requested Length: {totalLength} ft");
            //Console.WriteLine($"\t\t\t\tTotal Requested Weight: {totalweight} lb");


            #endregion
            var rebWas =
                _context.RebarWastings.Where(w => w.IsItAvailable == true).Select(s => s.RebarWastingQuantity * s.RebarWastingLength).Sum();
                //(from w in MyMethods.rebarfabricated
                // where rf.RebarFabricationReqNo != rf.RebarWastedReqNo
                //where rf.RebarFabricationReqNo != _context.RebarWastings.Where(w => w.IsItAvailable == true).Select(s => s.RebarWastingReqNo).First()
                    //union s in SmallStructuresTakeOffs.Models.Rebar on rf. equals s.
                    //group rf by rf.RebarFabricationNomination into fabs
                    //orderby fabs.Key
                //select rf.RebarWastedLength * rf.RebarWastedQuantity).Sum();

            ViewBag.TotalWaste = rebWas;


            var rebFab =
                from rf in MyMethods.rebarfabricated
                //union s in SmallStructuresTakeOffs.Models.Rebar on rf. equals s.
                    //group rf by rf.RebarFabricationNomination into fabs
                    //orderby fabs.Key
                select new RebarPresentationVM.RebarFabricationVM
                {
                    RebarWastedSource = rf.RebarWastedReqNo,
                    RebarFabricationVMId = rf.RebarFabricationReqNo,
                    RebarFabricationVMReqNo = rf.RebarFabricationReqNo,
                    RebarFabricationVMNomination = rf.RebarFabricationNomination,
                    RebarFabricationVMLength = rf.RebarFabricationLength,
                    RebarFabricationVMQuantity = rf.RebarFabricationQuantity,
                    RebarWastedLength = rf.RebarWastedLength,
                    RebarWastedQuantity = rf.RebarWastedQuantity,
                    RebarFabricationSource = rf.Source,
                    RebFabStructure = rf.RebFabStructure,
                    RebFabWeight = rf.RebarFabricationNomination == RebarNomination.No2 ? MyMethods.rInfo.Find(s => s.rNom == rf.RebarFabricationNomination.ToString()).rWeigth :
                        rf.RebarFabricationNomination == RebarNomination.No3 ? MyMethods.rInfo.Find(s => s.rNom == rf.RebarFabricationNomination.ToString()).rWeigth : 
                        rf.RebarFabricationNomination == RebarNomination.No4 ? MyMethods.rInfo.Find(s => s.rNom == rf.RebarFabricationNomination.ToString()).rWeigth :
                        rf.RebarFabricationNomination == RebarNomination.No5 ? MyMethods.rInfo.Find(s => s.rNom == rf.RebarFabricationNomination.ToString()).rWeigth : 0M
                };

            var rebReq =
                from rq in _context.RebarRequests
                where rq.RebReqProjId == id
                select new RebarPresentationVM.RebarRequestsVM
                {
                    RebarRequestVMId = rq.RebarRequestId,
                    RebarRequestVMNomination = rq.RebarRequestNomination,
                    RebarRequestVMQty = rq.RebarRequestQty,
                    RebarRequestVMLength = rq.RebarRequestLength,
                    RebarRequestVMStructure = rq.Structure
                };

            return View(rebFab.ToList());
        }
        #endregion

        #region My Methods
        public class MyMethods
        {
            #region Setting Up the Lists
            public static List<RebarInfo> rInfo = new() /*List<RebarInfo>*/
            {
                new RebarInfo { rNom = "No2", rWeigth = 0.176M },
                new RebarInfo { rNom = "No3", rWeigth = 0.376M },
                new RebarInfo { rNom = "No4", rWeigth = 0.668M },
                new RebarInfo { rNom = "No5", rWeigth = 1.05M }
            };

            public static List<RebarToPurchase> purchases = new();
            public static List<RebarWasting> rebarwastes = new();
            public static List<RebarFabrication> rebarfabricated = new();

            #endregion

            #region Method to Add Purchases, Wastes & Fabs
            public static void PurchasesAdd(RebarNomination rebNom, decimal length, int qty, int reqNo, long projId, EFCoreDBcontext _context, string structure, decimal nomLength)
            {

                #region Querying Rebar Wastes
                RebarWasting checkingwastes = new();
                checkingwastes = MyMethods.FindWaste(rebNom, length, qty, _context);
                #endregion Querying Rebar Wastes

                #region if-01. When Wastes are Null
                if (checkingwastes == null) //No Waste Available
                {
                    #region When Lengths are smaller then Stick Length 

                    if (length <= RebarLengths.RebLength20)
                    {

                        int eaInStick = (int)Math.Floor(RebarLengths.RebLength20/ length); // Requested Rebar in Stick

                        decimal num = ((decimal)qty / (decimal)eaInStick);
                        decimal Sticks = Math.Ceiling(num); // Stick to purchase for given Quantity

                        #region A. Checking if Qty satisfaid with full Sticks
                        if (qty % eaInStick == 0) // A.Checking if Qty satisfaid with full Sticks
                        {
                            purchases.Add(new RebarToPurchase
                            {
                                RebarNomLengths = nomLength,
                                RebarToPurchaseNomination = rebNom,
                                RebarToPurchaseQuantity = (int)Sticks,
                                RebarRequest = reqNo
                            });

                            decimal wasteLength1 = RebarLengths.RebLength20 - eaInStick * length;

                            if (wasteLength1 == 0)
                            {
                                int wasteQuantity12 = 0;
                                MyMethods.AddWaste(rebNom, wasteLength1, wasteQuantity12, reqNo, _context);

                                rebarfabricated.Add(new RebarFabrication
                                {
                                    //WasteId = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,
                                    //RebarRequestId = reqNo,
                                    RebFabStructure = structure,
                                    Source = checkingwastes == null ? FabricationSource.FullStick : FabricationSource.Waste,
                                    RebarWastedReqNo = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,
                                    RebarFabricationReqNo = reqNo,
                                    RebarFabricationNomination = rebNom,
                                    RebarFabricationLength = length,
                                    RebarFabricationQuantity = qty,
                                    RebarWastedLength = wasteLength1,
                                    RebarWastedQuantity = wasteQuantity12
                                });

                                return;
                            }

                            int wasteQuantity1 = (int)Sticks;

                            MyMethods.AddWaste(rebNom, wasteLength1, wasteQuantity1, reqNo, _context);

                            rebarfabricated.Add(new RebarFabrication
                            {
                                //WasteId = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,
                                //RebarRequestId = reqNo,
                                RebFabStructure = structure,
                                Source = checkingwastes == null ? FabricationSource.FullStick : FabricationSource.Waste,
                                RebarWastedReqNo = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,

                                RebarFabricationReqNo = reqNo,
                                RebarFabricationNomination = rebNom,
                                RebarFabricationLength = length,
                                RebarFabricationQuantity = qty,
                                RebarWastedLength = wasteLength1,
                                RebarWastedQuantity = wasteQuantity1
                            });
                            return;
                        }
                        #endregion

                        #region B. There's a remainder available
                        purchases.Add(new RebarToPurchase
                        {
                            RebarNomLengths = nomLength,
                            RebarToPurchaseNomination = rebNom,
                            RebarToPurchaseQuantity = (int)Sticks,
                            RebarRequest = reqNo
                        });

                        if (Math.Floor((decimal)(qty / eaInStick)) != 0)
                        {
                            decimal wasteLength1 = RebarLengths.RebLength20 - length * eaInStick;
                            int wasteQuantity1 = (int)Math.Floor((decimal)(qty / eaInStick));

                            if (wasteLength1 != 0)
                            {
                                MyMethods.AddWaste(rebNom, wasteLength1, wasteQuantity1, reqNo, _context);
                            }

                            rebarfabricated.Add(new RebarFabrication
                            {
                                //RebarFabricationId = rbFabId,
                                //WasteId = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,
                                RebFabStructure = structure,
                                Source = checkingwastes == null ? FabricationSource.FullStick : FabricationSource.Waste,
                                RebarWastedReqNo = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,

                                RebarFabricationReqNo = reqNo,
                                RebarFabricationNomination = rebNom,
                                RebarFabricationLength = length,
                                RebarFabricationQuantity = (int)Math.Floor((decimal)(qty / eaInStick)) * eaInStick,
                                RebarWastedLength = wasteLength1,
                                RebarWastedQuantity = wasteLength1 == 0 ? 0 : wasteQuantity1
                            });
                        }

                        decimal wasteLength2 = RebarLengths.RebLength20 - (qty % eaInStick) * length;
                        int wasteQuantity2 = 1;

                        MyMethods.AddWaste(rebNom, wasteLength2, wasteQuantity2, reqNo, _context);

                        rebarfabricated.Add(new RebarFabrication
                        {
                            //WasteId = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,
                            //RebarRequestId = reqNo,
                            RebFabStructure = structure,
                            Source = checkingwastes == null ? FabricationSource.FullStick : FabricationSource.Waste,
                            RebarWastedReqNo = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,

                            RebarFabricationReqNo = reqNo,
                            RebarFabricationNomination = rebNom,
                            RebarFabricationLength = length,
                            RebarFabricationQuantity = (qty % eaInStick),
                            RebarWastedLength = wasteLength2,
                            RebarWastedQuantity = wasteQuantity2
                        });

                        return;
                        #endregion  if-03

                        #region else. Non Existing
                        //else
                        //{
                        //    rebarfabricated.Add(new RebarFabrication { RebarFabricationLength = length, RebarFabricationNomination = rebNom, RebarFabricationQuantity = (int)Math.Floor(Sticks) * eaInStick, RebarFabricationReqNo = reqNo, Source = FabricationSource.FullStick }); // Added Fabricated pieces in a full Rebar Size
                        //    decimal wasteLength0 = RebarLengths. - eaInStick * length;
                        //    int wasteQuantity0 = (int)Math.Floor(Sticks);
                        //    MyMethods.AddWaste(rebNom, wasteLength0, wasteQuantity0, reqNo);

                        //    // Added Fabricated pieces remained in a Full Rebar Size
                        //    rebarfabricated.Add(new RebarFabrication { RebarFabricationLength = length, RebarFabricationNomination = rebNom, RebarFabricationQuantity = qty - (int)Math.Floor(Sticks) * eaInStick, RebarFabricationReqNo = reqNo, Source = FabricationSource.FullStick });
                        //    decimal wasteLength1 = RebarLengths. - (qty - (int)Math.Floor(Sticks) * eaInStick) * length;
                        //    int wasteQuantity1 = 1;
                        //    MyMethods.AddWaste(rebNom, wasteLength1, wasteQuantity1, reqNo);

                        //    return;
                        //}
                        #endregion else. 
                    }

                    #endregion if-02 Checking for lengths smaller than 20'

                    #region if-02. When Lengths are greater then Stick Length
                    else
                    {
                        return;
                    }
                    #endregion
                }
                #endregion if-01

                #region if-01. When Wastes aren't Null
                else
                {
                    // Calculating the Wastes
                    int eaInStick2 = (int)Math.Floor(checkingwastes.RebarWastingLength / length);
                    int wasteQtyAvailable = eaInStick2 * checkingwastes.RebarWastingQuantity;

                    #region C. When Qty is equal to WastQtyAvailable
                    if (qty == wasteQtyAvailable)
                    {
                        decimal wasteLength3 = checkingwastes.RebarWastingLength - eaInStick2 * length;
                        int wasteQty3 = checkingwastes.RebarWastingQuantity;

                        if (wasteLength3 != 0)
                        {
                            MyMethods.AddWaste(rebNom, wasteLength3, wasteQty3, reqNo, _context);
                        }


                        rebarfabricated.Add(new RebarFabrication
                        {
                            //WasteId = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,
                            //RebarRequestId = reqNo,
                            RebFabStructure = structure,
                            Source = checkingwastes == null ? FabricationSource.FullStick : FabricationSource.Waste,
                            RebarWastedReqNo = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,

                            RebarFabricationReqNo = reqNo,
                            RebarFabricationNomination = rebNom,
                            RebarFabricationLength = length,
                            RebarFabricationQuantity = qty,
                            RebarWastedLength = wasteLength3,
                            RebarWastedQuantity = wasteQty3
                        });

                        MyMethods.UpdateWaste(
                            checkingwastes.RebarWastingNomination,
                            checkingwastes.RebarWastingLength,
                            checkingwastes.RebarWastingQuantity,
                            checkingwastes.RebarWastingId,
                            checkingwastes.RebarWastingReqNo,
                            _context);

                        return;
                    }
                    #endregion if-07 

                    #region Qty is Greater then eaInAStick2 
                    if (qty > wasteQtyAvailable)
                    {
                        decimal wasteLength3 = checkingwastes.RebarWastingLength - eaInStick2 * length;
                        int wasteQty3 = checkingwastes.RebarWastingQuantity;

                        if (wasteLength3 != 0)
                        {
                            MyMethods.AddWaste(rebNom, wasteLength3, wasteQty3, reqNo, _context);
                        }

                        rebarfabricated.Add(new RebarFabrication
                        {
                            //WasteId = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,
                            //RebarRequestId = reqNo,
                            RebFabStructure = structure,
                            Source = checkingwastes == null ? FabricationSource.FullStick : FabricationSource.Waste,
                            RebarWastedReqNo = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,

                            RebarFabricationReqNo = reqNo,
                            RebarFabricationNomination = rebNom,
                            RebarFabricationLength = length,
                            RebarFabricationQuantity = wasteQtyAvailable,
                            RebarWastedLength = wasteLength3,
                            RebarWastedQuantity = wasteLength3 == 0 ? 0 : wasteQty3
                        });

                        MyMethods.UpdateWaste(
                            checkingwastes.RebarWastingNomination,
                            checkingwastes.RebarWastingLength,
                            checkingwastes.RebarWastingQuantity,
                            checkingwastes.RebarWastingId,
                            checkingwastes.RebarWastingReqNo,
                            _context);

                        var currentRequestCount =
                            (from cR in rebarfabricated
                             where cR.RebarFabricationNomination == rebNom &&
                            cR.RebarFabricationLength == length && cR.RebarFabricationReqNo == reqNo
                             select cR.RebarFabricationQuantity).LastOrDefault();

                        int remainingQty = qty - currentRequestCount;

                        PurchasesAdd(rebNom, length, remainingQty, reqNo, projId, _context, structure, RebarLengths.RebLength20);

                        return;

                    }

                    decimal wasteLength1 = checkingwastes.RebarWastingLength - eaInStick2*length;

                    int remQty = wasteQtyAvailable - qty;

                    if (qty % eaInStick2 == 0) {

                        MyMethods.AddWaste(
                            checkingwastes.RebarWastingNomination,
                            wasteLength1,
                            qty/eaInStick2,
                            checkingwastes.RebarWastingReqNo,
                            _context);

                        MyMethods.AddWaste(
                            checkingwastes.RebarWastingNomination,
                            checkingwastes.RebarWastingLength,
                            (int)Math.Floor((decimal)remQty/(decimal)eaInStick2),
                            checkingwastes.RebarWastingReqNo,
                            _context);

                        MyMethods.UpdateWaste(
                        checkingwastes.RebarWastingNomination,
                        checkingwastes.RebarWastingLength,
                        checkingwastes.RebarWastingReqNo,
                        checkingwastes.RebarWastingId,
                        checkingwastes.RebarWastingReqNo,
                        _context);

                        rebarfabricated.Add(new RebarFabrication
                        {
                            //WasteId = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,
                            //RebarRequestId = reqNo,
                            RebFabStructure = structure,
                            Source = checkingwastes == null ? FabricationSource.FullStick : FabricationSource.Waste,
                            RebarWastedReqNo = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,
                            RebarFabricationReqNo = reqNo,
                            RebarFabricationNomination = rebNom,
                            RebarFabricationLength = length,
                            RebarFabricationQuantity = qty,
                            RebarWastedLength = wasteLength1,
                            RebarWastedQuantity = (int)Math.Floor((decimal)remQty/(decimal)eaInStick2)
                        });


                        return;
                    }

                    if (wasteLength1 != 0) {

                        int wasteQty1 = (int)Math.Floor((decimal)qty/(decimal)eaInStick2);

                        MyMethods.AddWaste(
                            checkingwastes.RebarWastingNomination,
                            wasteLength1,
                            wasteQty1,
                            checkingwastes.RebarWastingReqNo,
                            _context);

                        MyMethods.AddWaste(
                            checkingwastes.RebarWastingNomination,
                            checkingwastes.RebarWastingLength,
                            (int)Math.Floor((decimal)remQty/(decimal)eaInStick2),
                            checkingwastes.RebarWastingReqNo,
                            _context);

                        MyMethods.UpdateWaste(
                        checkingwastes.RebarWastingNomination,
                        checkingwastes.RebarWastingLength, reqNo,
                        checkingwastes.RebarWastingId,
                        checkingwastes.RebarWastingReqNo,
                        _context);

                        rebarfabricated.Add(new RebarFabrication
                        {
                            //WasteId = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,
                            //RebarRequestId = reqNo,
                            RebFabStructure = structure,
                            Source = checkingwastes == null ? FabricationSource.FullStick : FabricationSource.Waste,
                            RebarWastedReqNo = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,
                            RebarFabricationReqNo = reqNo,
                            RebarFabricationNomination = rebNom,
                            RebarFabricationLength = length,
                            RebarFabricationQuantity = qty,
                            RebarWastedLength = wasteLength1,
                            RebarWastedQuantity = (int)Math.Floor((decimal)remQty/(decimal)eaInStick2)
                        });

                        return;


                    }

                    MyMethods.AddWaste(
                            checkingwastes.RebarWastingNomination,
                            checkingwastes.RebarWastingLength - (wasteQtyAvailable % qty) * length,
                            wasteQtyAvailable % qty,
                            checkingwastes.RebarWastingReqNo,
                            _context);

                    MyMethods.AddWaste(
                            checkingwastes.RebarWastingNomination,
                            checkingwastes.RebarWastingLength,
                            (int)Math.Floor((decimal)remQty/(decimal)eaInStick2),
                            checkingwastes.RebarWastingReqNo,
                            _context);

                    MyMethods.UpdateWaste(
                        checkingwastes.RebarWastingNomination,
                        checkingwastes.RebarWastingLength, reqNo,
                        checkingwastes.RebarWastingId,
                        checkingwastes.RebarWastingReqNo,
                        _context);

                    rebarfabricated.Add(new RebarFabrication
                    {
                        //WasteId = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,
                        //RebarRequestId = reqNo,
                        RebFabStructure = structure,
                        Source = checkingwastes == null ? FabricationSource.FullStick : FabricationSource.Waste,
                        RebarWastedReqNo = checkingwastes == null ? 0 : checkingwastes.RebarWastingReqNo,
                        RebarFabricationReqNo = reqNo,
                        RebarFabricationNomination = rebNom,
                        RebarFabricationLength = length,
                        RebarFabricationQuantity = qty,
                        RebarWastedLength = wasteLength1,
                        RebarWastedQuantity = (int)Math.Floor((decimal)remQty/(decimal)eaInStick2)
                    });

                    return;
                    /**********************************/



                }

                #endregion if-08


                #endregion

            }
            #endregion Waste Available

            #region List All Wastes
            public static void ListAllWastes(EFCoreDBcontext _context)
                {
                    decimal totalWaste = 0;
                    int totalSticks = 0;

                    foreach (RebarWasting waste in _context.RebarWastings.OrderBy(o => o.RebarWastingId))
                    {
                        decimal wasteLengthAvailable = waste.IsItAvailable == true ? waste.RebarWastingQuantity * waste.RebarWastingLength : 0;
                        int wasteQuantityAvailable = waste.IsItAvailable == true ? waste.RebarWastingQuantity : 0;

                        totalWaste += wasteLengthAvailable;
                        totalSticks += wasteQuantityAvailable;
                        Console.WriteLine($"ReqNo. {waste.RebarWastingReqNo},\t{waste.RebarWastingNomination}, \t{waste.RebarWastingQuantity} ea, \t{waste.RebarWastingLength} ft, \t{waste.IsItAvailable}, \t{wasteLengthAvailable} ");
                    }
                }

                #endregion

                #region Add Waste
                public static void AddWaste(RebarNomination rebNom, decimal length, int qty, int reqNo, EFCoreDBcontext _context)
                {
                    var thisWaste =
                        new RebarWasting
                        {
                            RebarWastingReqNo = reqNo,
                            RebarWastingLength = length,
                            RebarWastingNomination = rebNom,
                            RebarWastingQuantity = qty,
                            IsItAvailable = length <= 0 ? false : true,
                            RebarWastingId = 0
                        };
                    //rebarwastes.Add(thisWaste);
                    _context.RebarWastings.Add(thisWaste);
                    _context.SaveChanges();
                }
                #endregion

                #region Find Waste
                public static RebarWasting FindWaste(RebarNomination rebNom, decimal length, int qty, EFCoreDBcontext _context)
                {
                    var findW =
                        from f in _context.RebarWastings
                        where f.RebarWastingNomination == rebNom &&
                              f.RebarWastingLength >= length &&
                              f.IsItAvailable == true &&
                              f.RebarWastingQuantity > 0
                        orderby f.RebarWastingLength
                        select f;
                    return findW.FirstOrDefault();
                }

                #endregion

                #region Update Waste
                public static void UpdateWaste(RebarNomination rebNom, decimal lenght, int qty, int id, int reqNo, EFCoreDBcontext _context)
                {
                //var thisUpdate =
                //    (from u in _context.RebarWastings
                //    where u.RebarWastingId == id
                //    select new RebarWasting
                //    {
                //        RebarWastingReqNo = reqNo,
                //        IsItAvailable = false,
                //        RebarWastingLength = lenght,
                //        RebarWastingQuantity = qty,
                //        RebarWastingNomination = rebNom
                //        //RebarWastingId = id
                //    });

                var thisUpdate =
                     (from u in _context.RebarWastings
                     where u.RebarWastingId == id
                     select u).FirstOrDefault();
                //{
                //    RebarWastingReqNo = reqNo,
                //    IsItAvailable = false,
                //    RebarWastingLength = lenght,
                //    RebarWastingQuantity = qty,
                //    RebarWastingNomination = rebNom
                //                        //RebarWastingId = id
                //                    });

                thisUpdate.IsItAvailable = false;

                _context.Update<RebarWasting>(thisUpdate);
                    _context.SaveChanges();
                }

            #endregion

                #region Clear Waste
                public static void ClearWaste(EFCoreDBcontext _context)
                {
                    //using RebarDbContext db = new RebarDbContext();
                    IQueryable<RebarWasting> clrWastes =
                        from f in _context.RebarWastings
                        select f;
                    //rebWste = null;
                    _context.RebarWastings.RemoveRange(clrWastes);
                    _context.SaveChanges();
                }
                #endregion
        }
        #endregion
    }
}

