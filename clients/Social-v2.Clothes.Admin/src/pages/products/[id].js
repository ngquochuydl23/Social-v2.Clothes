import Head from 'next/head';
import {
  Box,
  Button,
  Container,
  Stack,
  Typography,
  Unstable_Grid2 as Grid,
  Popover,
  Drawer
} from '@mui/material';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import ProductDetailOptionItem from 'src/sections/products/product-detail/product-detail-option-item';
import _ from 'lodash';
import ProductDetailVarientItem from 'src/sections/products/product-detail/product-detail-varient';
import MoreVertIcon from '@mui/icons-material/MoreVert';
import { useState } from 'react';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import AlertDialog from 'src/components/alert-dialog';
import EditGeneralInfo from 'src/sections/products/edit-product/edit-general-info';
import CloseIcon from '@mui/icons-material/Close';

const product = {
  "title": "Nike Air Force 1 '07",
  "subtitle": "Men's Shoes",
  "description": "The radiance lives on in the Nike Air Force 1 '07, the basketball original that puts a fresh spin on what you know best: durably stitched overlays, clean finishes and the perfect amount of flash to make you shine.\n\nColour Shown: White/White\nStyle: CW2288-111",
  "handle": "/nike-air-force-1-'07",
  "isGiftCard": false,
  "isDiscountable": true,
  "collectionId": "winter-2023",
  "material": "",
  "thumbnail": "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/b7d9211c-26e7-431a-ac24-b0540fb3c00f/air-force-1-07-shoes-WrLlWX.png",
  "categories": [
    {
      "categoryId": "giay-the-thao"
    }
  ],
  "originalCountry": "Vietnam",
  "options": [
    {
      "title": "Color",
      "optionValues": [
        "White",
        "Black"
      ]
    },
    {
      "title": "Size",
      "optionValues": [
        "35",
        "36",
        "37",
        "38",
        "39",
        "40",
        "41",
        "42"
      ]
    }
  ],
  "productSkus": [
    {
      "title": "White 35",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "White"
        },
        {
          "option": "Size",
          "value": "35"
        }
      ],
      "stock": 5000
    },
    {
      "title": "Black 35",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "Black"
        },
        {
          "option": "Size",
          "value": "35"
        }
      ],
      "stock": 5000
    },
    {
      "title": "White 36",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "White"
        },
        {
          "option": "Size",
          "value": "36"
        }
      ],
      "stock": 5000
    },
    {
      "title": "Black 36",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "Black"
        },
        {
          "option": "Size",
          "value": "36"
        }
      ],
      "stock": 5000
    },
    {
      "title": "White 37",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "White"
        },
        {
          "option": "Size",
          "value": "37"
        }
      ],
      "stock": 5000
    },
    {
      "title": "Black 37",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "Black"
        },
        {
          "option": "Size",
          "value": "37"
        }
      ],
      "stock": 5000
    },
    {
      "title": "White 38",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "White"
        },
        {
          "option": "Size",
          "value": "38"
        }
      ],
      "stock": 5000
    },
    {
      "title": "Black 38",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "Black"
        },
        {
          "option": "Size",
          "value": "38"
        }
      ],
      "stock": 5000
    },
    {
      "title": "White 39",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "White"
        },
        {
          "option": "Size",
          "value": "39"
        }
      ],
      "stock": 5000
    },
    {
      "title": "Black 39",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "Black"
        },
        {
          "option": "Size",
          "value": "39"
        }
      ],
      "stock": 5000
    },
    {
      "title": "White 40",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "White"
        },
        {
          "option": "Size",
          "value": "40"
        }
      ],
      "stock": 5000
    },
    {
      "title": "Black 40",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "Black"
        },
        {
          "option": "Size",
          "value": "40"
        }
      ],
      "stock": 5000
    },
    {
      "title": "White 41",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "White"
        },
        {
          "option": "Size",
          "value": "41"
        }
      ],
      "stock": 5000
    },
    {
      "title": "Black 41",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "Black"
        },
        {
          "option": "Size",
          "value": "41"
        }
      ],
      "stock": 5000
    },
    {
      "title": "White 42",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "White"
        },
        {
          "option": "Size",
          "value": "42"
        }
      ],
      "stock": 5000
    },
    {
      "title": "Black 42",
      "price": 2929000,
      "skuValues": [
        {
          "option": "Color",
          "value": "Black"
        },
        {
          "option": "Size",
          "value": "42"
        }
      ],
      "stock": 5000
    }
  ]
}


const ProductDetailPage = () => {
  const [openEditGeneralDrawer, setOpenEditGeneralDrawer] = useState(false);
  const [openAlert, setOpenAlert] = useState(false);
  const [anchorEl, setAnchorEl] = useState(null);
  const open = Boolean(anchorEl);
  const id = open ? 'simple-popover' : undefined;
  return (
    <>
      <Head>
        <title>
          {product.title}
        </title>
      </Head>
      <Box
        component="main"
        sx={{ flexGrow: 1 }}>
        <Container maxWidth="lg">
          <Stack direction="row">
            <Box flex={1.5}>
              <Stack
                alignItems="center"
                justifyContent="space-between"
                direction="row">
                <Typography
                  mt="22px"
                  mb="20px"
                  fontSize="26px"
                  variant='h3'>
                  {product.title}
                </Typography>
                <Stack
                  color="black"
                  direction="row">
                  <Button
                    sx={{
                      width: '120px',
                      borderRadius: '4px',
                      height: '30px',
                      fontSize: '14px',
                      borderColor: '#606060',
                      color: '#606060'
                    }}
                    variant='outlined'>
                    Published
                  </Button>
                  <Button
                    onClick={(event) => setAnchorEl(event.currentTarget)}
                    sx={{ color: '#696969', height: '30px', }}>
                    <MoreVertIcon />
                  </Button>
                  <Popover
                    id={id}
                    open={open}
                    anchorEl={anchorEl}
                    onClose={() => setAnchorEl(null)}
                    anchorOrigin={{
                      vertical: 'bottom',
                      horizontal: 'left',
                    }}
                    PaperProps={{ sx: { width: 200, padding: '10px' } }}
                    transformOrigin={{
                      vertical: 'top',
                      horizontal: 'left',
                    }}>
                    <Stack
                      sx={{
                        width: '100%',
                        backgroundColor: 'white'
                      }}>
                      <Button
                        onClick={() => {
                          setAnchorEl(null);
                          setOpenEditGeneralDrawer(true);
                        }}
                        startIcon={<EditIcon />}
                        sx={{ color: '#696969' }}
                        variant='text'>
                        Edit general info
                      </Button>
                      <Button
                        onClick={() => setOpenAlert(true)}
                        sx={{ color: 'red' }}
                        startIcon={<DeleteIcon />}
                        variant='text'>
                        Delete product
                      </Button>
                    </Stack>
                  </Popover>
                </Stack>
              </Stack>
              <Typography
                mb="40px"
                color="#696969"
                fontStyle="300"
                fontSize="16px"
                variant='caption'>
                {product.description}
              </Typography>
              <Box>

              </Box>
              <Box>
                <Typography
                  mt="22px"
                  mb="20px"
                  fontSize="20px"
                  variant='h3'>
                  Options
                </Typography>
                <Grid container >
                  {_.map(product.options, (option, index) => (
                    <Grid item xs={6}>
                      <ProductDetailOptionItem
                        index={index}
                        title={option.title}
                        optionValues={option.optionValues}
                      />
                    </Grid>
                  ))}
                </Grid>
              </Box>
              <Box>
                <Typography
                  mt="22px"
                  mb="20px"
                  fontSize="20px"
                  variant='h3'>
                  Variants
                </Typography>
                <Stack>
                  {_.map(product.productSkus, (pSku, index) => (
                    <Grid item xs={6}>
                      <ProductDetailVarientItem
                        {...pSku}

                      />
                    </Grid>
                  ))}
                </Stack>
              </Box>
              <Box mb={'40px'}>
                <Typography
                  mt="22px"
                  mb="20px"
                  fontSize="20px"
                  variant='h3'>
                  Attributes
                </Typography>
                <Typography
                  fontSize="18px"
                  variant='subtitle1'>
                  Dimensions
                </Typography>
                <Stack
                  mt={"10px"}
                  direction="row"
                  justifyContent="space-between">
                  <Typography
                    fontSize="14px"
                    variant='subtitle2'>
                    Height
                  </Typography>
                  <Typography
                    fontSize="14px"
                    variant='subtitle2'>
                    {`114cm`}
                  </Typography>
                </Stack>
                <Stack
                  mt={"10px"}
                  direction="row"
                  justifyContent="space-between">
                  <Typography
                    fontSize="14px"
                    variant='subtitle2'>
                    Width
                  </Typography>
                  <Typography
                    fontSize="14px"
                    variant='subtitle2'>
                    {`57cm`}
                  </Typography>
                </Stack>
                <Stack
                  mt={"10px"}
                  direction="row"
                  justifyContent="space-between">
                  <Typography
                    fontSize="14px"
                    variant='subtitle2'>
                    Length
                  </Typography>
                  <Typography
                    fontSize="14px"
                    variant='subtitle2'>
                    {`48cm`}
                  </Typography>
                </Stack>
                <Stack
                  mt={"10px"}
                  direction="row"
                  justifyContent="space-between">
                  <Typography
                    fontSize="14px"
                    variant='subtitle2'>
                    Length
                  </Typography>
                  <Typography
                    fontSize="14px"
                    variant='subtitle2'>
                    {`800g`}
                  </Typography>
                </Stack>
              </Box>
            </Box>
            <Box flex={1}>

            </Box>
          </Stack >
        </Container >
      </Box >
      <AlertDialog
        title={"Delete product?"}
        leftTxt={"Cancel"}
        rightTxt={"Yes"}
        content={"Are you sure you want to delete this product?"}
        open={openAlert}
        onRightClick={() => {
          setOpenAlert(false);
        }}
        onLeftClick={() => setOpenAlert(false)}
        handleClose={() => setOpenAlert(false)} />
      <Drawer
        anchor="right"
        sx={{ maxWidth: '200px' }}
        open={openEditGeneralDrawer}
        onClose={() => setOpenEditGeneralDrawer(false)}>
        <Stack
          sx={{ mt: '10px' }}
          alignItems="center"
          direction="row">
          <Button
            onClick={() => setOpenEditGeneralDrawer(false)}
            sx={{ color: 'black' }}
            variant='text'>
            <CloseIcon />
          </Button>
          <Typography
            fontSize="20px"
            variant='h4'>
            Edit general information
          </Typography>
        </Stack>
        <EditGeneralInfo product={product} />
      </Drawer>
    </>
  )
}

ProductDetailPage.getLayout = (page) => (
  <DashboardLayout>
    {page}
  </DashboardLayout>
);

export default ProductDetailPage;
