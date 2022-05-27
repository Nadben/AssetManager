import * as React from "react"
import { Link } from "gatsby"
import { StaticImage } from "gatsby-plugin-image"
import { Header } from '../components/Header'
import { MainWrapper } from '../components/MainWrapper'
import { Page } from '../styles/Page.styled'

import '../styles/module.scss'

const IndexPage = () => (
  <Page>
    <MainWrapper />
  </Page>
)

export default IndexPage