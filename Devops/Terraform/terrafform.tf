provider "google" {
  credentials = "${file("account.json")}"
  project = "wt-gd-pdd2"
  region  = "asia-east1"
  zone    = "asia-east1-a"
}

resource "google_compute_firewall" "ssh" {
  name    = "hrs-test-firewall"
  network = google_compute_network.test_vpc_network.id

  allow {
    protocol = "tcp"
    ports    = ["22"]
  }

  source_ranges = ["0.0.0.0/0"]
  target_tags = ["hrs-gcpdev-ssh-test"]
}

resource "google_compute_firewall" "http" {
  name    = "hrs-test-http"
  network = google_compute_network.test_vpc_network.id

  allow {
    protocol = "tcp"
    ports    = ["80"]
  }

  source_ranges = ["0.0.0.0/0"]
  target_tags = ["hrs-gcpdev-http-test"]
}

resource "google_compute_instance" "test_vm" {
  name         = "hrs-dev-deploy-linux-asia-east1-a-1-test"
  machine_type = "e2-standard-2"
   #public_ips     = ["34.81.76.129"]

# metadata = {
#   enable-oslogin = "TRUE"
#    ssh-keys = "bbking:ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDEKlEvhaMPM9heKjflYYvsx1yRad2DngPhLQuaMzMGGkJO0tWG2IPlO+7teCkFnPT4onTt+c1zwFWUhpTTwGOV2LnSQXxTUJlzX0EqCBZ1y0smZRDae/2zd8HEW+8Kv33uKnLg6wKhIw2+mCCD84kaRbaFK2Bfyfp2bcjf2IKvI7+5Yea/mPoa1KWNhVQyx5D1Bc7w1kpsKj3OOclnAZm/L50aGV+FJbC+HrM7hrKdIFbdI68axfl1WtSOrsxIXvKTPUxLywJCyquLN1aHpCGYFrElZ1Ch8p21EM/Xqo118kdQYsJgio6B/DCYmHN8LhYwOJTcuA8CkH2JZn2705FcrfwgevFQKPpgnNCKemxUcYfTZ19EqD16/IoFlHF9UKLERA5pODodMaHJbEHiu48jI5PgqbI9JSdcJNX5YZ8TaxRgBjjv7drwSp4UNYd20Y+boyrHzhaWZP6bBenu04mndOujcoQ2aawdT//F6P+d18EfBMVmmN+BQrGHZ6JF2Bk= bbking"
# }

  boot_disk {
    initialize_params {
       size = 50
       image = "debian-cloud/debian-11"
    }
  }

  tags = ["http-server", "https-server", "hrs-gcpdev-ssh-test", "hrs-gcpdev-http-test"]

  network_interface {
    # A default network is created for all GCP projects
    network    = google_compute_network.test_vpc_network.id
    subnetwork = google_compute_subnetwork.test_subnet.id
    access_config {
        nat_ip = "34.81.76.129"   # Already Set fixed public IP, before.
    }
  }
}

resource "google_compute_network" "test_vpc_network" {
  name = "hrs-test-network"
  auto_create_subnetworks = false
}

resource "google_compute_subnetwork" "test_subnet" {
  name          = "hrs-test-subnetwork"
  ip_cidr_range = "10.55.0.0/24"  
  network       = google_compute_network.test_vpc_network.id
}

