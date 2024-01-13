import React from "react";
import { Link } from "react-router-dom";
import LazyLoadingImage from "../LazyLoadingImage";
const { format } = require('number-currency-format');



const ProductCard = ({ id,
    title,
    tags,
    thumbnail,
    subtitle,
    subcategory,
    brand,
    price, }) => {
    return (
        <>
            <div
                className="relative flex flex-col bg-transparent"
                data-nc-id="ProductCard">
                <Link
                    className="absolute inset-0"
                    to={`/products/${id}`}
                ></Link>
                <div className="relative flex-shrink-0 bg-slate-50 rounded-2xl overflow-hidden z-1 group">
                    <Link
                        className="block"
                        to={`/product/${id}`}>
                        <div
                            className="nc-NcImage flex aspect-w-11 aspect-h-12 w-full h-0"
                            data-nc-id="NcImage">
                            <LazyLoadingImage
                                height={"322"}
                                width={"296"}
                                src={"https://clothes-dev.social-v2.com/" + thumbnail}
                                className="max-w-full object-contain w-full h-full drop-shadow-xl"
                            />
                        </div>
                    </Link>
                </div>
                <div className="space-y-4 px-2.5 pt-5 pb-2.5">
                    <div>
                        <h2 className="text-base font-semibold text-black line-clamp-1">
                            {title}
                        </h2>
                        <p className="text-sm font-normal text-slate-500 mt-1 line-clamp-2">
                            {subtitle}
                        </p>
                    </div>
                    <div className="flex justify-between items-end">
                        <div className="">
                            <div className="flex items-center  rounded-lg py-1 text-lg font-medium">
                                <span className="text-black-600">
                                    {format(price, { currency: 'đ', thumbnail: ',' })}
                                </span>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </>
    );
};

export default ProductCard;
