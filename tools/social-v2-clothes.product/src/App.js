import { Container, DialogContent, Grid, Stack, TextField } from '@mui/material';
import './App.css';
import { useEffect, useState } from 'react';
import Dialog from '@mui/material/Dialog';
import { Chips } from 'primereact/chips';

const CreateProductOptionButton = ({ onClick }) => {
  return (
    <button
      onClick={onClick}
      style={{
        backgroundColor: '#f5f5f5',
        height: '60px',
        fontWeight: 600,
        borderRadius: '4px'
      }}>
      Create Product Option
    </button>
  )
}

const OptionDialog = ({ open, onClose, onOk }) => {
  const [value, setValue] = useState([]);
  const [title, setTitle] = useState('');

  const customChip = (item) => {
    return (
      <div>
        <span>{item}</span>
        <i className="pi pi-user-plus"></i>
      </div>
    );
  };
  return (
    <Dialog
      fullScreen={false}
      open={open}
      maxWidth='xl'
      onClose={() => onClose}
      aria-labelledby="responsive-dialog-title">
      <DialogContent >
        <div style={{ width: 500 }}>
          <TextField
            value={title}
            fullWidth
            onChange={(e) => setTitle(e.target.value)}
            label="Option title"
            id="fullWidth" />
          <div
            className="card p-fluid"
            style={{
              marginTop: '20px',
              backgroundColor: '#f5f5f5',
              padding: '20px',
              borderRadius: '10px'
            }}>
            <Chips
              value={value}
              itemTemplate={customChip}
              onChange={(e) => setValue(e.value)} />
          </div>
        </div>
        <button
          onClick={() => {
            onOk({
              title: title,
              optionValues: value
            })
            setTitle('')
            setValue([])
            onClose()
          }}
          style={{
            width: '100%',
            height: '40px',
            marginTop: '20px'
          }}>
          Create Product Option
        </button>
      </DialogContent>
    </Dialog>
  )
}

const App = () => {
  const [openDialog, setOpenDialog] = useState(false);
  const [product, setProduct] = useState({
    title: '',
    subtitle: '',
    description: '',
    isGiftCard: true,
    discountable: true,
    thumbnail: true,
    handle: '',
    weight: 0,
    length: 0,
    width: 0,
    originalCountry: 'Vietnam',
    material: '',
    collectionId: null,
    options: [],
    productSkus: [],
    categories: []
  })

  const generateSku = (options) => {
    var productSkus = [];
    var skuValues = [];

    var dem = 0;

    for (let nRoot = 0; nRoot < options[0].optionValues; nRoot++) {
      
      for (let dLevel = 1; dLevel < options.length; dLevel++) { 
        
      }
    }
    return skuValues;
  }

  useEffect(() => {
    console.log(product)
    console.log(generateSku(product.options));
  }, [product.options])



  return (
    <Container style={{ marginTop: 50 }}>
      <Grid container spacing='15px'>
        <Grid item xs={6}>
          <Stack spacing="20px">
            <TextField fullWidth label="Title" id="fullWidth" />
            <TextField fullWidth label="Subtitle" id="fullWidth" />
            <TextField fullWidth label="Weight" id="fullWidth" />
            <TextField fullWidth label="Length" id="fullWidth" />
            <TextField fullWidth label="Width" id="fullWidth" />
            <TextField fullWidth label="Original Country" id="fullWidth" />
            <TextField fullWidth label="Material" id="fullWidth" />
            <CreateProductOptionButton onClick={() => {
              setOpenDialog(true)
            }} />
          </Stack>
        </Grid>
        <Grid item xs={6}>
          {Boolean(product.options) &&
            <Stack>
              {product.options.map((option) => {
                return (
                  <div>
                    <span>{option.title}: </span>
                    {option.optionValues.map((optionValue) => {
                      return (
                        <span>{optionValue}, </span>
                      )
                    })}
                  </div>
                )
              })}
            </Stack>
          }
          <Stack>

          </Stack>
        </Grid>
      </Grid>
      <OptionDialog
        open={openDialog}
        onClose={() => setOpenDialog(false)}
        onOk={(option) => {
          setProduct({
            ...product,
            options: [...product.options, option]
          })
        }} />
    </Container>
  )
}

export default App;
