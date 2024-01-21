import React from "react";
import * as Carousel from "../Carousel";
import GrayText from "./GrayText";

import { Link } from "react-router-dom";
import LazyLoadingImage from "../LazyLoadingImage";
import DashboardLoading from "../loading/DashboardLoading";
import ProductCard from "./ProductCard";

const NewArrivals = ({ products, loading, type }) => {
  return (
    <>
      {loading ? (
        <DashboardLoading />
      ) : products?.length ? (
        <div className="flex flex-col gap-y-8 !relative">
          <div className="lg:mb-8 mb-6">
            <h2 className=" text-3xl md:text-4xl font-semibold">
              New Arrivals<span className="">. </span>
              <GrayText>New Sports equipment</GrayText>
            </h2>
          </div>
          <div>
            <Carousel.Component
              options={{
                type: type, // carousel or slide
                perView: 4,
                gap: 30,
                breakpoints: {
                  576: {
                    perView: 1,
                  },
                  768: {
                    perView: 2,
                  },
                  820: {
                    perView: 3,
                  },
                  1024: {
                    perView: 4,
                  },
                },
              }}
            >
              {products?.map(
                (product) => (
                  <Carousel.Slide key={product.id}>
                    <ProductCard {...product}/>
                  </Carousel.Slide>
                )
              )}
            </Carousel.Component>
          </div>
        </div>
      ) : (
        <div
          className="flex p-4 mb-4 text-sm text-yellow-800 border border-yellow-300 rounded-lg bg-yellow-50 justify-center"
          role="alert">
          <svg
            aria-hidden="true"
            className="flex-shrink-0 inline w-5 h-5 mr-3"
            fill="currentColor"
            viewBox="0 0 20 20"
            xmlns="http://www.w3.org/2000/svg">
            <path
              fillRule="evenodd"
              d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-7-4a1 1 0 11-2 0 1 1 0 012 0zM9 9a1 1 0 000 2v3a1 1 0 001 1h1a1 1 0 100-2v-3a1 1 0 00-1-1H9z"
              clipRule="evenodd"
            ></path>
          </svg>
          <span className="sr-only">Warning</span>
          <div>
            <span className="font-medium">Warning alert!</span> No product added
            yet!
          </div>
        </div>
      )}
    </>
  );
};

export default NewArrivals;