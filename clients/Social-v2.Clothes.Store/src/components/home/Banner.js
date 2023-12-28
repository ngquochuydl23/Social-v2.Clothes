import React from "react";
import Searchbar from "./Searchbar";
import LazyLoadingImage from "../LazyLoadingImage";

const Banner = () => {
  return (
    <>
      <section className="">
        <section className="h-[67vh] overflow-hidden bg-[#f8f0ea]">
          <div
            className="bg-center bg-no-repeat h-full relative"
            style={{ backgroundImage: "url(/assets/banner/banner-bg.svg)" }}
          >
            {/* <Searchbar /> */}
            <div className="absolute top-0 left-0 h-full w-full bg-black/30 z-10 lg:hidden" />
            <LazyLoadingImage
              src="/assets/banner/banner-model.png"
              alt="banner model"
              className="absolute bottom-0 right-0 lg:w-[40%]"
              height={"614"}
              width={"100%"}
            />
          </div>
        </section>
      </section>
    </>
  );
};

export default Banner;
