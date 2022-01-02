using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectResto.Controllers.Personnels
{

    using ProjectResto.Models.Personnels;
    using ProjectResto.Models.Restaurant;
    using ProjectResto.Models.BDD;
    using ProjectResto.Controllers.Restaurant;
    class MaitreHotelController : PersonneController
    {
        private readonly MaitreHotel maitreHotel;
        public MaitreHotelController(MaitreHotel maitreHotel)
        {
            personnes = new List<Personne>();
            connection = DBUtils.GetDBConnection();
            this.maitreHotel = maitreHotel;
            SetTableName("MaitreHotel");
        }
        public void ReceiveClient()
        {
            maitreHotel.ReceiveClient();
        }

    }
}
