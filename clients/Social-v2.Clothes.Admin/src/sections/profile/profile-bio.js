import React from 'react';
import PropTypes from 'prop-types';
import { Stack } from '@mui/system';
import { Button, Typography } from '@mui/material';

const ProfileBio = (props) => {
  const { artistId } = props;
  return (
    <Stack direction="column">
      <Stack
        direction="row"
        alignItems="center"
        justifyContent="space-between"
        sx={{ width: '50%' }}>
        <Typography
          variant='h5'>
          Bio
        </Typography>
        <Button
          sx={{ fontSize: '16px'}}
          variant='text'>
          Edit
        </Button>
      </Stack>
      <Typography
        sx={{ width: '50%', marginTop: '20px' }}
        variant='body1'>
        {`Taylor Alison Swift (born December 13, 1989) is an American singer-songwriter. Recognized for her songwriting, musical versatility, artistic reinventions, and influence on the music industry, she is a prominent cultural figure of the 21st century.

Swift began professional songwriting at age 14 and signed with Big Machine Records in 2005 to become a country singer. Under Big Machine, she released six studio albums, four of them to country radio, starting with her self-titled album in 2006. Her next, Fearless (2008), explored country pop, and its singles "Love Story" and "You Belong with Me" catapulted her to prominence. Speak Now (2010) incorporated rock influences, while Red (2012) experimented with electronic elements and featured Swift's first Billboard Hot 100 number-one song, "We Are Never Ever Getting Back Together". She departed from her country image with 1989 (2014), a synth-pop album supported by the chart-topping songs "Shake It Off", "Blank Space", and "Bad Blood". Media scrutiny inspired the hip-hop-flavored Reputation (2017) and its number-one single "Look What You Made Me Do".`}
      </Typography>
      <Typography
        sx={{ width: '50%', marginTop: '30px' }}
        variant='h5'>
        Images
      </Typography>
    </Stack>
  )
}

ProfileBio.propTypes = {
  artistId: PropTypes.number.isRequired,
};

export default ProfileBio;