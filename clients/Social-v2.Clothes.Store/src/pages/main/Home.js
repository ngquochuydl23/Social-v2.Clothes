import React from "react";
import Banner from "../../components/home/Banner";
import BuyingSteps from "../../components/home/BuyingSteps";
import NewArrivals from "../../components/home/NewArrivals";
import KidsProduct from "../../components/home/KidsProduct";
import ExpertChoice from "../../components/home/ExpertChoice";
import StartExploring from "../../components/home/StartExploring";
import TrendingNow from "../../components/home/TrendingNow";
import EarnMoney from "../../components/home/EarnMoney";
import CategoryCards from "../../components/home/CategoryCards";

const Home = () => {
  const products = [
    {
      thumbnail: 'https://image.uniqlo.com/UQ/ST3/AsianCommon/imagesgoods/460322/item/goods_31_460322.jpg?width=750',
      title: 'Áo Nỉ',
      subcategory: {
        title: 'Áo nỉ & Hoodies'
      },
      description: 'Kết cấu tốt và màu sắc tuyệt đẹp. Được thiết kế dựa trên chi tiết áo len truyền thống.',
      price: 500000
    }
  ];

  const categories = [
    {
      id : 1,
      title: 'Quần Áo',
      thumbnail: 'https://ciseco-reactjs.vercel.app/static/media/explore1.3017824afbd558dae323.png'
    }
  ]

  return (
    <section className="container mx-auto flex flex-col gap-y-32 px-4">
      <Banner />
      <div className="lg:px-32 flex flex-col gap-y-32">
        <NewArrivals
          products={products}
          loading={false}
          type={"carousel"}
        />
        <KidsProduct />
        <ExpertChoice
          products={products.slice(-3)}
          loading={true}
          type={"slide"}
        />
        <StartExploring />
        <TrendingNow products={products.slice(-12)} loading={true} />
        <EarnMoney />
      </div>
    </section>
  );
};

export default Home;
