using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularVize.Models;
using AngularVize.ViewModel;
using System.IO;
using System.Drawing;

namespace AngularVize.Controllers
{
    public class ServisController : ApiController
    {
        DB01Entities db = new DB01Entities();
        SonucModel sonuc = new SonucModel();

        #region Dosya

        [HttpGet]
        [Route("api/dosyalistele")]
        public List<DosyaModel> DosyaListe()
        {

            List<DosyaModel> liste = db.TDosyalar.Select(x => new DosyaModel()
            {

                dosyaId = x.dosyaId,
                dosyaAdi = x.dosyaAdi,
                dosyaFoto = x.dosyaFoto
              



            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/dosyabyid/{dosyaId}")]

        public DosyaModel DosyaById(string dosyaId)
        {
            DosyaModel kayit = db.TDosyalar.Where(s => s.dosyaId == dosyaId).Select(x => new DosyaModel()
            {

                dosyaId = x.dosyaId,
                dosyaAdi = x.dosyaAdi,
                dosyaFoto = x.dosyaFoto


            }).SingleOrDefault();
            return kayit;

        }

        [HttpPost]
        [Route("api/dosyaekle")]

        public SonucModel DosyaEkle(DosyaModel model)
        {

            TDosyalar yeni = new TDosyalar();
            yeni.dosyaId = Guid.NewGuid().ToString();
            yeni.dosyaAdi = model.dosyaAdi;
           // yeni.dosyaFoto = model.dosyaFoto;
            db.TDosyalar.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Dosya Eklendi";

            return sonuc;


        }

        [HttpPut]
        [Route("api/dosyaduzenle")]

        public SonucModel DosyaDuzenle(DosyaModel model)
        {
            TDosyalar kayit = db.TDosyalar.Where(s => s.dosyaId == model.dosyaId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Dosya Bulunamadı";
                return sonuc;
            }

            kayit.dosyaAdi = model.dosyaAdi;
           // kayit.dosyaFoto = model.dosyaFoto;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Dosya Düzenlendi";

            return sonuc;

        }


        [HttpDelete]
        [Route("api/dosyasil/{dosyaId}")]

        public SonucModel DosyaSil(string dosyaId)
        {
            TDosyalar kayit = db.TDosyalar.Where(s => s.dosyaId == dosyaId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Dosya Bulunamadı";
                return sonuc;
            }

            //if (db.tdosyakayit.count(s => s.dkdosyaıd == dosyaıd) > 0)
            //{
            //    sonuc.islem = false;
            //    sonuc.mesaj = "dosyanın üzerine ders kayıtlı olduğu için dosya silinemez ";
            //    return sonuc;
            //}

            db.TDosyalar.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Dosya Silindi";

            return sonuc;
        }
         
        #endregion


        #region Uye





        #endregion

    }


}
