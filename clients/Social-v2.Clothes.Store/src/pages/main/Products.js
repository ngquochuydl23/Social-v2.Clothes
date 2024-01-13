import { Box, Grid, Typography } from '@mui/material';
import ProductCard from '../../components/home/ProductCard';

const Products = () => {





    return (
        <section className="container mx-auto flex flex-col gap-y-32 px-4">
            <div className="lg:px-32 flex flex-col">

                <Box mt="20px">
                    <Typography
                        color="black"
                        fontWeight={600}
                        variant='h5'>Kết quả tìm kiếm</Typography>
                </Box>
                <Grid container columnSpacing="15px">
                    <Grid item xs={2.4}>
                        <ProductCard
                            id="ao-so-mi-khong-can-ui-slim-fit-dai-tay"
                            title="Áo Sơ Mi Không Cần Ủi Slim Fit Dài Tay"
                            thumbnail="/storage/c29jaWFsLXYyLmNsb3RoZXMtMTcwMzkwNjU0NTc2Mg=="
                            description="Chống nhăn sau khi giặt để dễ chăm sóc. Kết cấu cotton tự nhiên cho vẻ ngoài thanh lịch."
                            price={785000}
                        />
                    </Grid>
                    <Grid item xs={2.4}>
                        <ProductCard
                            id="ao-so-mi-khong-can-ui-slim-fit-dai-tay"
                            title="Áo Sơ Mi Không Cần Ủi Slim Fit Dài Tay"
                            thumbnail="/storage/c29jaWFsLXYyLmNsb3RoZXMtMTcwMzkwNjU0NTc2Mg=="
                            description="Chống nhăn sau khi giặt để dễ chăm sóc. Kết cấu cotton tự nhiên cho vẻ ngoài thanh lịch."
                            price={785000}
                        />
                    </Grid>
                    <Grid item xs={2.4}>
                        <ProductCard
                            id="ao-so-mi-khong-can-ui-slim-fit-dai-tay"
                            title="Áo Sơ Mi Không Cần Ủi Slim Fit Dài Tay"
                            thumbnail="/storage/c29jaWFsLXYyLmNsb3RoZXMtMTcwMzkwNjU0NTc2Mg=="
                            description="Chống nhăn sau khi giặt để dễ chăm sóc. Kết cấu cotton tự nhiên cho vẻ ngoài thanh lịch."
                            price={785000}
                        />
                    </Grid>
                    <Grid item xs={2.4}>
                        <ProductCard
                            id="ao-so-mi-khong-can-ui-slim-fit-dai-tay"
                            title="Áo Sơ Mi Không Cần Ủi Slim Fit Dài Tay"
                            thumbnail="/storage/c29jaWFsLXYyLmNsb3RoZXMtMTcwMzkwNjU0NTc2Mg=="
                            description="Chống nhăn sau khi giặt để dễ chăm sóc. Kết cấu cotton tự nhiên cho vẻ ngoài thanh lịch."
                            price={785000}
                        />
                    </Grid>
                    <Grid item xs={2.4}>
                        <ProductCard
                            id="ao-so-mi-khong-can-ui-slim-fit-dai-tay"
                            title="Áo Sơ Mi Không Cần Ủi Slim Fit Dài Tay"
                            thumbnail="/storage/c29jaWFsLXYyLmNsb3RoZXMtMTcwMzkwNjU0NTc2Mg=="
                            description="Chống nhăn sau khi giặt để dễ chăm sóc. Kết cấu cotton tự nhiên cho vẻ ngoài thanh lịch."
                            price={785000}
                        />
                    </Grid>
                </Grid>
            </div>
        </section>
    )
}

export default Products;