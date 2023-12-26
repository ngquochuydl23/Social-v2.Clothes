import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import { useSelector } from "react-redux";
import { useUpdatePhotoMutation } from "../../features/update/updateApi";
import { useUpdateUserMutation } from "../../features/auth/authApi";
import LazyLoadingImage from "../../components/LazyLoadingImage";
import { Box, Button, Container, Divider, FormControlLabel, Grid, MenuItem, Stack, Switch, TextField, Typography } from '@mui/material';

const Profile = () => {
  const {
    auth: {
      user: { _id, name, email, dob, avatar, gender, phone, address },
    },
    update: { photo },
  } = useSelector((state) => state);

  // react hook form credentials
  const { register, handleSubmit, reset } = useForm({
    defaultValues: {
      name,
      email,
      gender,
      phone,
      dob,
      address,
      avatar,
    },
  });

  return (
    <>
      <div className="container mx-auto lg:px-0 px-4">
        <div className="max-w-4xl mx-auto pt-14 sm:pt-26 pb-24 lg:pb-32">
          <div className="space-y-10 sm:space-y-12">
            <h2 className="text-2xl sm:text-3xl font-semibold">
              Account information
            </h2>
            <div className="flex flex-col md:flex-row">
              <div className="flex-shrink-0 flex items-start">
                <div className="relative rounded-full overflow-hidden flex">
                  <LazyLoadingImage
                    src={"https://img.freepik.com/premium-psd/3d-male-cute-cartoon-character-avatar-isolated-3d-rendering_235528-1280.jpg"}
                    alt={
                      Object.keys(photo)?.length
                        ? photo?.public_id
                        : avatar?.public_id
                    }
                    className="w-32 h-32 rounded-full object-cover object-center z-0"
                    height={"128"}
                    width={"128"}
                  />
                </div>
              </div>
              <form
                // onSubmit={handleSubmit(handleUpdateUserAccount)}
                className="flex-grow mt-10 md:mt-0 md:pl-16 max-w-3xl space-y-6"
              >
                <TextField
                    required
                    fullWidth
                    id="subtitle"
                    label="Full name"
                    
                  // onChange={formik.handleChange}
                  // value={formik.values.subtitle}
                  />
                <TextField
                    required
                    fullWidth
                    id="subtitle"
                    label="Email"
                    
                  // onChange={formik.handleChange}
                  // value={formik.values.subtitle}
                  />
                 <TextField
                    required
                    fullWidth
                    id="subtitle"
                    label="Date of birth"
                    
                  // onChange={formik.handleChange}
                  // value={formik.values.subtitle}
                  />
                
                <div>
                  <label
                    className="nc-Label text-base font-medium text-neutral-900"
                    data-nc-id="Label"
                  >
                    Gender
                  </label>
                  <select
                    name="gender"
                    {...register("gender", { required: false })}
                    className="nc-Select h-11 mt-1.5 block w-full text-sm rounded-2xl border-neutral-200 focus:border-primary-300 focus:ring focus:ring-primary-200 focus:ring-opacity-50 bg-white"
                  >
                    <option selected={gender === "male"} value="male">
                      Male
                    </option>
                    <option selected={gender === "female"} value="female">
                      Female
                    </option>
                    <option selected={gender === "binary"} value="binary">
                      Binary
                    </option>
                  </select>
                </div>
                <TextField
                    required
                    fullWidth
                    id="subtitle"
                    label="Phone number"
                    
                  // onChange={formik.handleChange}
                  // value={formik.values.subtitle}
                  />
                <Button variant="contained">
                  Save
                </Button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Profile;
