import React, { useEffect, useState } from "react";
import Banner from "../../components/home/Banner";
import BuyingSteps from "../../components/home/BuyingSteps";
import NewArrivals from "../../components/home/NewArrivals";
import KidsProduct from "../../components/home/KidsProduct";
import ExpertChoice from "../../components/home/ExpertChoice";
import StartExploring from "../../components/home/StartExploring";
import TrendingNow from "../../components/home/TrendingNow";
import EarnMoney from "../../components/home/EarnMoney";
import CategoryCards from "../../components/home/CategoryCards";
import { getNewArrivals } from "../../services/api/product-api";

const Home = () => {
    const [newArrivals, setNewArrivals] = useState([]);

    const categories = [
        {
            id: 1,
            title: 'Quần Áo',
            thumbnail: 'https://ciseco-reactjs.vercel.app/static/media/explore1.3017824afbd558dae323.png'
        }
    ]

    useEffect(() => {
        getNewArrivals()
            .then((res) => setNewArrivals(res))
            .catch((err) => console.log(err))
    }, [])


    return (
        <section className="container mx-auto flex flex-col gap-y-32 px-4">
            {/* <Banner /> */}
            <div className="lg:px-32 flex flex-col gap-y-32">
                <NewArrivals
                    products={newArrivals}
                    loading={false}
                    type={"carousel"}
                />
                <KidsProduct />
                <ExpertChoice
                    products={newArrivals.slice(-3)}
                    loading={true}
                    type={"slide"}
                />
                <StartExploring />
                <TrendingNow products={newArrivals.slice(-12)} loading={true} />
                <EarnMoney />
            </div>
        </section>
    );
};

export default Home;
