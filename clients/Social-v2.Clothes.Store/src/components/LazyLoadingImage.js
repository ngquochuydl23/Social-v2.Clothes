import React from "react";
import { LazyLoadImage } from "react-lazy-load-image-component";

const LazyLoadingImage = ({ src, alt, height, width, className, onClick, placeholderSrc }) => {
  return (
    <>
      <LazyLoadImage
        src={src}
        alt={alt}
        onClick={onClick}
        height={height}
        width={width}
        placeholderSrc={placeholderSrc}
        className={`max-w-full object-cover object-center ${className}`}
      />
    </>
  );
};

export default LazyLoadingImage;
